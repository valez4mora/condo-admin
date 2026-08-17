using DAL.DAO;
using DTO;
using Integration.TipoCambio;
using Interfaces;
using System;
using System.Collections.Generic;
using Util.Factura;

namespace BLL
{
    public class FacturaBLL
    {
        private readonly IFacturaDAL _facturaDAL;
        private readonly CargoFacturableBLL _cargoBLL;
        private readonly ITipoCambioService _tipoCambioService;

        public FacturaBLL()
        {
            _facturaDAL = new FacturaDAO();
            _cargoBLL = new CargoFacturableBLL();
            _tipoCambioService = new TipoCambioService();
        }

        // 1. GENERAR FACTURA — Cuota ordinaria de mantenimiento
        /// Calcula la cuota de mantenimiento, crea el cargo en la base
        /// de datos, obtiene el tipo de cambio y emite la factura.
        public FacturaDTO GenerarFacturaCuotaOrdinaria(
            PropiedadDTO propiedad)
        {
            if (propiedad == null)
            {
                throw new ArgumentNullException(
                    "propiedad",
                    "La propiedad no puede ser nula.");
            }

            CargoFacturableDTO cargo =
                _cargoBLL.GenerarCuotaOrdinaria(propiedad);

            return ConstruirYPersistirFactura(
                propiedad.IdPropiedad,
                propiedad.Codigo,
                cargo);
        }

        // 2. GENERAR FACTURA — Cargo manual
        /// Genera una factura para un cargo manual registrado.
        /// El cargo debe encontrarse en estado Pendiente.
        public FacturaDTO GenerarFacturaManual(
            CargoFacturableDTO cargo,
            string codigoPropiedad)
        {
            if (cargo == null)
            {
                throw new ArgumentNullException(
                    "cargo",
                    "El cargo no puede ser nulo.");
            }

            if (cargo.IdPropiedad <= 0)
            {
                throw new Exception(
                    "El cargo debe estar asociado a una propiedad.");
            }

            if (cargo.IdCargo <= 0)
            {
                throw new Exception(
                    "El cargo debe estar registrado antes de facturarlo.");
            }

            CargoFacturableDTO existente =
                _cargoBLL.ObtenerPorId(cargo.IdCargo);

            if (existente == null)
            {
                throw new Exception(
                    "No se encontró el cargo indicado.");
            }

            if (!string.Equals(
                existente.Estado,
                "Pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                    "Solo se pueden facturar cargos pendientes.");
            }

            if (_facturaDAL.ExisteFacturaParaCargo(cargo.IdCargo))
            {
                throw new Exception(
                    "El cargo seleccionado ya se encuentra facturado.");
            }

            return ConstruirYPersistirFactura(
                cargo.IdPropiedad,
                codigoPropiedad,
                existente);
        }

        // 3. ANULAR FACTURA
        /// Anula una factura existente.
        /// No permite anular facturas anuladas o pagadas.
        public bool AnularFactura(int idFactura)
        {
            if (idFactura <= 0)
            {
                throw new Exception(
                    "Debe indicar un Id de factura válido.");
            }

            FacturaDTO existente =
                _facturaDAL.ObtenerPorId(idFactura);

            if (existente == null)
            {
                throw new Exception(
                    "No se encontró la factura indicada.");
            }

            if (string.Equals(
                existente.Estado,
                "Anulada",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                    "La factura ya se encuentra anulada.");
            }

            if (string.Equals(
                existente.Estado,
                "Pagada",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                    "No se puede anular una factura que ya fue pagada.");
            }

            return _facturaDAL.Anular(idFactura);
        }

        // 4. XML Y CORREO

        /// <summary>
        /// Genera el XML de la factura, lo guarda en la base de datos
        /// y devuelve el contenido generado.
        /// </summary>
        public string GenerarYGuardarXml(FacturaDTO factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException("factura");
            }

            string xml = XmlFacturaUtil.GenerarXml(factura);

            _facturaDAL.GuardarXml(
                factura.IdFactura,
                xml);

            return xml;
        }

        /// Envía la factura por correo con los archivos XML y PDF.
        public void EnviarPorCorreo(
            FacturaDTO factura,
            string emailDestinatario,
            string rutaPdf = null)
        {
            if (factura == null)
            {
                throw new ArgumentNullException("factura");
            }

            if (string.IsNullOrWhiteSpace(emailDestinatario))
            {
                throw new Exception(
                    "Debe indicar un correo destinatario.");
            }

            string xml = XmlFacturaUtil.GenerarXml(factura);

            string asunto =
                "Factura #" + factura.IdFactura +
                " — Propiedad " + factura.CodigoPropiedad;

            string cuerpo = EmailUtil.ConstruirCuerpoFactura(
                factura.CodigoPropiedad,
                factura.IdFactura,
                factura.Fecha.ToString("dd/MM/yyyy"),
                factura.TotalColones.ToString("N2"),
                factura.TotalDolares.ToString("N2"));

            bool pdfTemporal =
                string.IsNullOrWhiteSpace(rutaPdf);

            if (pdfTemporal)
            {
                rutaPdf = PdfFacturaUtil.GuardarEnArchivo(
                    factura,
                    System.IO.Path.GetTempPath());
            }

            try
            {
                EmailUtil.EnviarFactura(
                    emailDestinatario,
                    asunto,
                    cuerpo,
                    rutaPdf,
                    xml,
                    factura.IdFactura);
            }
            finally
            {
                if (pdfTemporal &&
                    System.IO.File.Exists(rutaPdf))
                {
                    System.IO.File.Delete(rutaPdf);
                }
            }

            _facturaDAL.GuardarXml(
                factura.IdFactura,
                xml);
        }

        // 5. CONSULTAS

        public FacturaDTO ObtenerPorId(int idFactura)
        {
            if (idFactura <= 0)
            {
                throw new Exception(
                    "Id de factura no válido.");
            }

            return _facturaDAL.ObtenerPorId(idFactura);
        }

        public List<FacturaDTO> ObtenerPorPropiedad(
            int idPropiedad)
        {
            if (idPropiedad <= 0)
            {
                throw new Exception(
                    "Id de propiedad no válido.");
            }

            return _facturaDAL.ObtenerPorPropiedad(
                idPropiedad);
        }

        public List<FacturaDTO> ObtenerTodas()
        {
            return _facturaDAL.ObtenerTodas();
        }

        // HELPER PRIVADO — construye y persiste la factura

        private FacturaDTO ConstruirYPersistirFactura(
            int idPropiedad,
            string codigoPropiedad,
            CargoFacturableDTO cargo)
        {
            if (cargo == null)
            {
                throw new ArgumentNullException(
                    "cargo",
                    "No se proporcionó el cargo que será facturado.");
            }

            if (idPropiedad <= 0)
            {
                throw new Exception(
                    "La propiedad de la factura no es válida.");
            }

            if (string.IsNullOrWhiteSpace(codigoPropiedad))
            {
                throw new Exception(
                    "Debe indicar el código de la propiedad.");
            }

            DetalleFacturaDTO detalle =
                new DetalleFacturaDTO
                {
                    IdCargo = cargo.IdCargo,
                    DescripcionCargo = cargo.Descripcion,
                    Cantidad = 1,
                    Precio = cargo.Total,
                    SubTotal = cargo.Total
                };

            decimal totalColones = detalle.SubTotal;

            TipoCambioResponseDTO cambio =
                _tipoCambioService.ObtenerTipoCambio();

            if (cambio == null || cambio.Valor <= 0)
            {
                throw new Exception(
                    "El servicio externo no devolvió un " +
                    "tipo de cambio válido.");
            }

            decimal totalDolares = Math.Round(
                totalColones / cambio.Valor,
                2,
                MidpointRounding.AwayFromZero);

            FacturaDTO factura = new FacturaDTO
            {
                Fecha = DateTime.Now,
                TotalColones = totalColones,
                TotalDolares = totalDolares,
                TipoCambio = cambio.Valor,
                TotalPagado = 0m,
                SaldoPendiente = totalColones,
                IdPropiedad = idPropiedad,
                CodigoPropiedad = codigoPropiedad.Trim(),
                Estado = "Emitida",
                Detalles = new List<DetalleFacturaDTO>
                {
                    detalle
                }
            };

            int idGenerado =
                _facturaDAL.Registrar(factura);

            if (idGenerado <= 0)
            {
                throw new Exception(
                    "No se pudo guardar la factura en la base de datos.");
            }

            factura.IdFactura = idGenerado;

            // El XML se genera como parte de la emisión.
            GenerarYGuardarXml(factura);

            return factura;
        }
    }
}