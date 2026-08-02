using DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PropiedadBLL
    {
        PropiedadDAL dal = new PropiedadDAL();

            public bool Registrar(PropiedadDTO propiedad)
            {

                if (string.IsNullOrEmpty(propiedad.Codigo))
                {
                    throw new Exception("Debe ingresar un código");
                }


                if (propiedad.Area <= 0)
                {
                    throw new Exception("El área debe ser mayor a cero");
                }


                if (dal.ExisteCodigo(propiedad.Codigo))
                {
                    throw new Exception("El código ya existe");
                }


                return dal.Registrar(propiedad);
            }
        
    }
}

