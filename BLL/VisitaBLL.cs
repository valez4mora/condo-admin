using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.DAO;  

namespace BLL
{
    public class VisitaBLL
    {
        private readonly VisitaDAO visitaDAO = new VisitaDAO();

        // -------------------------------------------------------
        // Registra una visita nueva y genera su código QR
        // Devuelve el VisitaDTO con IdVisita y CodigoQR asignados
        // -------------------------------------------------------
        public VisitaDTO RegistrarVisita(VisitaDTO visita)
        {
            ValidarVisita(visita);

            // 1. Insertar en BD (sin QR todavía, el ID no existe aún)
            visita.CodigoQR = string.Empty;
            int idGenerado = visitaDAO.Registrar(visita);

            if (idGenerado <= 0)
                throw new Exception("No se pudo registrar la visita en la base de datos.");

            visita.IdVisita = idGenerado;

            // 2. Generar código QR con el ID ya conocido
            visita.CodigoQR = GenerarCodigoQR(idGenerado, visita.IdPropiedad, visita.Fecha);

            // 3. Actualizar el QR en la BD
            visitaDAO.ActualizarQR(idGenerado, visita.CodigoQR);

            return visita;
        }

        // -------------------------------------------------------
        // Registra la salida de un visitante
        // -------------------------------------------------------
        public bool RegistrarSalida(int idVisita)
        {
            VisitaDTO visita = visitaDAO.ObtenerPorId(idVisita);

            if (visita == null)
                throw new Exception("La visita no existe.");

            if (visita.HoraSalida.HasValue)
                throw new Exception("Esta visita ya tiene registrada una hora de salida.");

            return visitaDAO.RegistrarSalida(idVisita, DateTime.Now);
        }

        // -------------------------------------------------------
        // Obtiene el historial con filtros opcionales
        // -------------------------------------------------------
        public List<VisitaDTO> ObtenerPorFiltros(int? idPropiedad, DateTime? fecha, string estado)
        {
            return visitaDAO.ObtenerPorFiltros(idPropiedad, fecha, estado);
        }

        // -------------------------------------------------------
        // Valida un código QR escaneado: devuelve la visita o null
        // -------------------------------------------------------
        public VisitaDTO ValidarQR(string codigoQR)
        {
            if (string.IsNullOrWhiteSpace(codigoQR))
                throw new Exception("El código QR no puede estar vacío.");

            return visitaDAO.ObtenerPorQR(codigoQR);
        }

        // -------------------------------------------------------
        // Genera el texto que se codifica en el QR
        // Formato: VISITA-{IdVisita}-{IdPropiedad}-{Fecha:yyyyMMdd}
        // -------------------------------------------------------
        public string GenerarCodigoQR(int idVisita, int idPropiedad, DateTime fecha)
        {
            return $"VISITA-{idVisita}-{idPropiedad}-{fecha:yyyyMMdd}";
        }

        // -------------------------------------------------------
        // Validaciones de negocio
        // -------------------------------------------------------
        private void ValidarVisita(VisitaDTO visita)
        {
            if (string.IsNullOrWhiteSpace(visita.NombreVisitante))
                throw new Exception("El nombre del visitante es obligatorio.");

            if (visita.IdPropiedad <= 0)
                throw new Exception("Debe seleccionar una propiedad de destino.");

            if (visita.Fecha == DateTime.MinValue)
                throw new Exception("La fecha de visita no es válida.");
        }
    }
}
