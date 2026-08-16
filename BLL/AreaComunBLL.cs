using System;
using DTO;
using DAL.DAO;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AreaComunBLL
    {
        private readonly IAreaComunDAL _dal;

        public AreaComunBLL()
        {
            _dal = new AreaComunDAO();
        }

        //registrar
        public bool Registrar(AreaComunDTO area)
        {
            ValidarArea(area);

            if (ExisteNombreEnBD(area.Nombre, 0))
                throw new Exception($"Ya existe un área con el nombre \"{area.Nombre}\".");

            return _dal.Insertar(area);
        }


        //modificar
        public bool Modificar (AreaComunDTO area)
        {
            if (area.IdArea <= 0)
                throw new Exception("Debe seleccionar un área común para modificar.");
            ValidarArea(area);

            // Verificar que el área exista
            AreaComunDTO existente = _dal.ObtenerPorId(area.IdArea);
            if (existente == null)
                throw new Exception("El área seleccionada no existe en la base de datos.");

            // Si cambió el nombre, verificar que no esté duplicado en otra área
            if (!existente.Nombre.Equals(area.Nombre, StringComparison.OrdinalIgnoreCase)
                && ExisteNombreEnBD(area.Nombre, area.IdArea))
                throw new Exception($"Ya existe otra área con el nombre \"{area.Nombre}\".");

            return _dal.Actualizar(area);

        }

        //eliminar
        public bool Eliminar (int idArea)
        {
            if (idArea <= 0)
                throw new Exception("Debe seleccionar un área común para eliminar.");

            AreaComunDTO existente = _dal.ObtenerPorId(idArea);
            if (existente == null)
                throw new Exception("El área seleccionada no existe.");

            try
            {
                return _dal.Eliminar(idArea);
            }
            catch (Exception ex)
            {
               
                throw new Exception("No es posible eliminar el área: " + ex.Message);
            }
        }

        //consultar areas
        public List<AreaComunDTO> ObtenerTodas()
        {
            return _dal.ObtenerTodas();
        }

        public AreaComunDTO ObtenerPorId(int idArea)
        {
            if (idArea <= 0)
                throw new Exception("Id de área inválido.");

            return _dal.ObtenerPorId(idArea);
        }

        //validaciones
        private void ValidarArea(AreaComunDTO area)
        {
            if (area == null)
                throw new ArgumentNullException("El objeto área no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(area.Nombre))
                throw new Exception("El nombre del área es obligatorio.");

            if (area.Nombre.Length > 100)
                throw new Exception("El nombre no puede superar 100 caracteres.");

            if (area.CapacidadMaxima <= 0)
                throw new Exception("La capacidad máxima debe ser mayor a cero.");

            if (area.Tarifa < 0)
                throw new Exception("La tarifa no puede ser un valor negativo.");
            if (area.HoraCierre <= area.HoraApertura)
                throw new Exception("La hora de cierre debe ser posterior a la hora de apertura.");

        }


        private bool ExisteNombreEnBD(string nombre, int idExcluir)
        {
            // se obtienen todas las filas
      
            List<AreaComunDTO> todas = _dal.ObtenerTodas();
            foreach (AreaComunDTO a in todas)
            {
                if (a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
                    && a.IdArea != idExcluir)
                    return true;
            }
            return false;
        }


    }
    }
