using DAL.DAO;
using DTO;
using Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Factura;
using Integration.BCCR;

namespace BLL
{
    /// <summary>
    /// Lógica de negocio para facturas.
    /// Genera facturas de cuota ordinaria, cargos manuales (multas, reservas, etc.),
    /// obtiene el tipo de cambio del BCCR, genera XML y coordina el envío por correo.
    /// </summary>
    public class FacturaBLL
    {
        private readonly IFacturaDAL _facturaDAL;
        private readonly CargoFacturableBLL _cargoBLL;

        public FacturaBLL()
        {
            _facturaDAL = new FacturaDAO();
            _cargoBLL = new CargoFacturableBLL();
        }

        // ══════════════════════════════════════════════════════════════
        // 1. GENERAR FACTURA — Cuota ordinaria de mantenimiento
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Calcula la cuota de mantenimiento, crea el cargo en BD,
        /// obtiene el tipo de cambio BCCR y emite la factura.
        /// </summary>
        public FacturaDTO GenerarFacturaCuotaOrdinaria(PropiedadDTO propiedad)
        {
            if (propiedad == null)
                throw new ArgumentNullException("propiedad", "La propiedad no puede ser nula.");

            // Genera y persiste el CargoFacturable
            CargoFacturableDTO cargo = _cargoBLL.GenerarCuotaOrdinaria(propiedad);

            return ConstruirYPersistirFactura(propiedad.IdPropiedad,
                                              propiedad.Codigo,
                                              cargo);
        }

        // ══════════════════════════════════════════════════════════════
        // 2. GENERAR FACTURA — Cargo manual (multa, extraordinaria, reserva)
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Genera la factura para un cargo manual ya registrado en BD.
        /// El cargo debe estar en estado "Pendiente".
        /// </summary>
        public FacturaDTO GenerarFacturaManual(CargoFacturableDTO cargo, string codigoPropiedad)
        {
            if (cargo == null)
                throw new ArgumentNullException("cargo", "El cargo no puede ser nulo.");

            if (cargo.IdPropiedad <= 0)
                throw new Exception("El cargo debe estar asociado a una propiedad.");

            return ConstruirYPersistirFactura(cargo.IdPropiedad, codigoPropiedad, cargo);
        }

        // ══════════════════════════════════════════════════════════════
        // 3. ANULAR FACTURA
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Anula una factura existente. Solo se pueden anular facturas "Emitidas".
        /// </summary>
        public bool AnularFactura(int idFactura)
        {
            if (idFactura <= 0)
                throw new Exception("Debe indicar un Id de factura válido.");

            FacturaDTO existente = _facturaDAL.ObtenerPorId(idFactura);
            if (existente == null)
                throw new Exception("No se encontró la factura indicada.");

            if (existente.Estado == "Anulada")
                throw new Exception("La factura ya se encuentra anulada.");

            if (existente.Estado == "Pagada")
                throw new Exception("No se puede anular una factura que ya fue pagada.");

            return _facturaDAL.Anular(idFactura);
        }

        // ══════════════════════════════════════════════════════════════
        // 4. XML Y CORREO
        // ══════════════════════════════════════════════════════════════

        /// <summary>
        /// Genera el XML de la factura, lo guarda en BD y retorna el string XML.
        /// </summary>
        public string GenerarYGuardarXml(FacturaDTO factura)
        {
            if (factura == null)
                throw new ArgumentNullException("factura");

            string xml = XmlFacturaUtil.GenerarXml(factura);
            _facturaDAL.GuardarXml(factura.IdFactura, xml);
            return xml;
        }

        /// <summary>
        /// Envía la factura por correo al destinatario indicado
        /// con los archivos XML (y PDF si se indica la ruta) adjuntos.
        /// </summary>
        public void EnviarPorCorreo(FacturaDTO factura, string emailDestinatario, string rutaPdf = null)
        {
            if (factura == null)
                throw new ArgumentNullException("factura");

            if (string.IsNullOrWhiteSpace(emailDestinatario))
                throw new Exception("Debe indicar un correo destinatario.");

            // Genera o recupera el XML
            string xml = XmlFacturaUtil.GenerarXml(factura);

            string asunto = $"Factura #{factura.IdFactura} — Propiedad {factura.CodigoPropiedad}";

            string cuerpo = EmailUtil.ConstruirCuerpoFactura(
                factura.CodigoPropiedad,
                factura.IdFactura,
                factura.Fecha.ToString("dd/MM/yyyy"),
                factura.TotalColones.ToString("N2"),
                factura.TotalDolares.ToString("N2"));

            EmailUtil.EnviarFactura(emailDestinatario, asunto, cuerpo, rutaPdf, xml, factura.IdFactura);

            // Guarda el XML en BD por si se necesita posteriormente
            _facturaDAL.GuardarXml(factura.IdFactura, xml);
        }

        // ══════════════════════════════════════════════════════════════
        // 5. CONSULTAS
        // ══════════════════════════════════════════════════════════════

        public FacturaDTO ObtenerPorId(int idFactura)
        {
            if (idFactura <= 0)
                throw new Exception("Id de factura no válido.");

            return _facturaDAL.ObtenerPorId(idFactura);
        }

        public List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new Exception("Id de propiedad no válido.");

            return _facturaDAL.ObtenerPorPropiedad(idPropiedad);
        }

        public List<FacturaDTO> ObtenerTodas()
        {
            return _facturaDAL.ObtenerTodas();
        }

        // ══════════════════════════════════════════════════════════════
        // HELPER PRIVADO — construye y persiste la factura
        // ══════════════════════════════════════════════════════════════

        private FacturaDTO ConstruirYPersistirFactura(int idPropiedad,
                                                      string codigoPropiedad,
                                                      CargoFacturableDTO cargo)
        {
            // Detalle con el cargo indicado
            DetalleFacturaDTO detalle = new DetalleFacturaDTO
            {
                IdCargo = cargo.IdCargo,
                DescripcionCargo = cargo.Descripcion,
                Cantidad = 1,
                Precio = cargo.Total,
                SubTotal = cargo.Total
            };

            // Tipo de cambio desde BCCR
            decimal totalColones = detalle.SubTotal;
            BCCRService bccr = new BCCRService();
            decimal totalDolares = bccr.ConvertirColonesADolares(totalColones);

            FacturaDTO factura = new FacturaDTO
            {
                Fecha = DateTime.Now,
                TotalColones = totalColones,
                TotalDolares = totalDolares,
                IdPropiedad = idPropiedad,
                CodigoPropiedad = codigoPropiedad,
                Estado = "Emitida",
                Detalles = new List<DetalleFacturaDTO> { detalle }
            };

            int idGenerado = _facturaDAL.Registrar(factura);

            if (idGenerado <= 0)
                throw new Exception("No se pudo guardar la factura en la base de datos.");

            factura.IdFactura = idGenerado;
            return factura;
        }
    }
}
