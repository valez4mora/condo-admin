using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface ICargoFacturableDAL
    {
     
      bool Registrar(CargoFacturableDTO cargo);  //Inserta un nuevo Cargo en la tabla CargoFacturable
        
        List<CargoFacturableDTO> ObtenerPorPropiedad(int idPropiedad);//trae todos los cargos que le pertenecen a una propiedad especifica

        List<CargoFacturableDTO> ObtenerTodos();//trae todos los cargos de todas la propiedades 

        List<CargoFacturableDTO> ObtenerVencidosSinPenalizar();
        bool ActualizarPenalizacion(CargoFacturableDTO cargo);

    }
}
