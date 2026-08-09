using DAL.DAO;
using DTO;
using Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class FacturaBLL
    {

        //tasa de cambio 
        private const decimal TIPO_CAMBIO = 515.00m;

        private readonly IFacturaDAL _facturaDAL;
        private readonly CargoFacturableBILL _cargoBLL;

        //constructor
        public FacturaBLL()
        {
            _facturaDAL = new FacturaDAO();
            _cargoBLL = new CargoFacturableBILL();
        }

        public FacturaDTO GenerarFacturaCuotaOrdinaria(PropiedadDTO propiedad)
        {
            if(propiedad== null)
            {
                throw new ArgumentNullException( "La propiedad no puede ser nula.");
            }

            CargoFacturableDTO cargo = _cargoBLL.GenerarCuotaOrdinaria(propiedad);

            // se crea el detalle de la factura con ese cargo
            DetalleFacturaDTO detalle = new DetalleFacturaDTO
            {
                IdCargo = cargo.IdCargo,
                DescripcionCargo = cargo.Descripcion,
                Cantidad = 1,          // una cuota ordinaria
                Precio = cargo.Total, // precio con IVA incluido
                SubTotal = cargo.Total


            };

            // calcular totales
            decimal totalColones = detalle.SubTotal;
            // Conversión a dólares
            decimal totalDolares = Math.Round(totalColones / TIPO_CAMBIO, 2);

            //  cabecera de la factura
            FacturaDTO factura = new FacturaDTO
            {
                Fecha = DateTime.Now,
                TotalColones = totalColones,
                TotalDolares = totalDolares,
                IdPropiedad = propiedad.IdPropiedad,
                CodigoPropiedad = propiedad.Codigo,
                Estado = "Emitida",
                Detalles = new List<DetalleFacturaDTO> { detalle }
            };

            int idGenerado = _facturaDAL.Registrar(factura);

            if (idGenerado <= 0)
                throw new Exception("No se pudo guardar la factura en la base de datos.");

            factura.IdFactura = idGenerado;
            return factura;
        }

        public List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new ArgumentException("Id de propiedad no válido.");

            return _facturaDAL.ObtenerPorPropiedad(idPropiedad);
        }

        public List<FacturaDTO> ObtenerTodas()
        {
            return _facturaDAL.ObtenerTodas();
        }



    }
}
