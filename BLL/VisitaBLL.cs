using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
 
    public class VisitaBLL
    {
     
        private readonly IVisitaDAL _dal;

        public VisitaBLL()
        {
            _dal = new VisitaDAO();
        }

     //registrar visita y generar QR
        public VisitaDTO RegistrarVisita(VisitaDTO visita)
        {
            ValidarVisita(visita);

            // Hora de entrada 
            visita.HoraEntrada = DateTime.Now.TimeOfDay;
            visita.CodigoQR = string.Empty;

            //  insertar y obtener el Id generado por la BD
            int idGenerado = _dal.Registrar(visita);

            if (idGenerado <= 0)
                throw new Exception("No se pudo registrar la visita en la base de datos.");

            visita.IdVisita = idGenerado;

            //  generar código QR con el Id ya conocido
            visita.CodigoQR = $"VISITA-{idGenerado}-{visita.IdPropiedad}-{visita.Fecha:yyyyMMdd}";

            //  guardar el QR en la BD
            _dal.ActualizarQR(idGenerado, visita.CodigoQR);

            return visita;
        }

       
        // Validar el QR
        // El guardia escanea o escribe el código QR
        public VisitaDTO ValidarAccesoQR(string codigoQR)
        {
            if (string.IsNullOrWhiteSpace(codigoQR))
                throw new Exception("El código QR no puede estar vacío.");

            VisitaDTO visita = _dal.ObtenerPorQR(codigoQR);

            if (visita == null)
                throw new Exception(
                    "Código QR no válido. No se encontró ninguna visita con ese código.");

            if (visita.HoraSalida.HasValue)
                throw new Exception(
                    $"Este QR ya fue utilizado. " +
                    $"{visita.NombreVisitante} registró salida a las {visita.HoraSalidaTexto}.");

            return visita;
        }

      //registrar salida
        public bool RegistrarSalida(int idVisita)
        {
            if (idVisita <= 0)
                throw new Exception("Id de visita inválido.");

            VisitaDTO visita = _dal.ObtenerPorId(idVisita);

            if (visita == null)
                throw new Exception("La visita no existe.");

            if (visita.HoraSalida.HasValue)
                throw new Exception("Esta visita ya tiene registrada una hora de salida.");

            // Hora de salida
            return _dal.RegistrarSalida(idVisita, DateTime.Now.TimeOfDay);
        }

        // historial con filtros
        public List<VisitaDTO> ObtenerHistorial(int? idPropiedad, DateTime? fecha, string estado)
        {
            return _dal.ObtenerPorFiltros(idPropiedad, fecha, estado);
        }

        //validaciones 
        private void ValidarVisita(VisitaDTO visita)
        {
            if (string.IsNullOrWhiteSpace(visita.NombreVisitante))
                throw new Exception("El nombre del visitante es obligatorio.");

            if (visita.NombreVisitante.Length > 100)
                throw new Exception("El nombre no puede superar 100 caracteres.");

            if (visita.IdPropiedad <= 0)
                throw new Exception("Debe seleccionar una propiedad de destino.");

            if (visita.Fecha == DateTime.MinValue)
                throw new Exception("La fecha de visita no es válida.");

            if (visita.Fecha.Date < DateTime.Today)
                throw new Exception("La fecha de visita no puede ser en el pasado.");
        }
    }
}