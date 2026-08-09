using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFacturaDAL
    {

        int Registrar(FacturaDTO factura); //inserta una factura con su detalle en la base de datos 

        List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad); //obtiene todas las facturas de una propiedad

        List<FacturaDTO> ObtenerTodas();//obtiene todas las facturas de todas las propiedades







    }
}
