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
    public class ReservaBLL
    {

        private readonly IReservaDAL _dal;
        private readonly IAreaComunDAL _dalArea;

        public ReservaBLL()
        {
            _dal = new ReservaDAO();
            _dalArea = new AreaComunDAO();
        }


        //crear la reserva 
        public bool CrearReserva(ReservaDTO reserva)
        {
            ValidarReserva(reserva);


            //Morosidad
            // mas de 90 días  suspensión temporal de reservas de áreas comunes
            int mesesMora = _dal.ObtenerMesesMoraPropiedad(reserva.IdPropiedad);
            if (mesesMora > 3) // 
                throw new Exception(
                    $"La propiedad tiene {mesesMora} meses de mora. " +
                    "Las reservas están suspendidas para propiedades con más de 90 días de mora.");

            //bloqueo por mantenimiento 
            if (_dal.VerificarBloqueoMantenimiento(reserva.IdArea, reserva.Fecha))
                throw new Exception(
                    "El área está bloqueada por mantenimiento en la fecha seleccionada. " +
                    "Elegí otra fecha.");

            //capacidad 
            AreaComunDTO area = _dalArea.ObtenerPorId(reserva.IdArea);
            if (area == null)
                throw new Exception("El área seleccionada no existe.");

            if (reserva.CantidadPersonas > area.CapacidadMaxima)
                throw new Exception(
                    $"La cantidad de personas ({reserva.CantidadPersonas}) supera " +
                    $"la capacidad máxima del área ({area.CapacidadMaxima} personas).");


            reserva.Estado = "Pendiente";

            try
            {
                return _dal.Insertar(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo crear la reserva: " + ex.Message);
            }
        }

        //aprobar reserva 

        public bool Aprobar(int idReserva)
        {
            ReservaDTO reserva = _dal.ObtenerPorId(idReserva);
            if (reserva == null)
                throw new Exception("La reserva no existe.");

            if (reserva.Estado != "Pendiente")
                throw new Exception($"Solo se pueden aprobar reservas en estado Pendiente. " +
                                    $"Estado actual: {reserva.Estado}.");

            return _dal.CambiarEstado(idReserva, "Confirmada", null);
        }


        //cancelacion
        public bool Cancelar(int idReserva, string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new Exception("Debe indicar el motivo de cancelación.");

            ReservaDTO reserva = _dal.ObtenerPorId(idReserva);
            if (reserva == null)
                throw new Exception("La reserva no existe.");

            if (reserva.Estado == "Cancelada")
                throw new Exception("La reserva ya está cancelada.");

            return _dal.CambiarEstado(idReserva, "Cancelada", motivo);
        }

        //rechazar reserva 

        public bool Rechazar(int idReserva, string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new Exception("Debe indicar el motivo de rechazo.");

            ReservaDTO reserva = _dal.ObtenerPorId(idReserva);
            if (reserva == null)
                throw new Exception("La reserva no existe.");

            if (reserva.Estado != "Pendiente")
                throw new Exception("Solo se pueden rechazar reservas en estado Pendiente.");

            // Guardamos "Rechazada: [motivo]" para distinguirlo de una cancelación normal
            return _dal.CambiarEstado(idReserva, "Cancelada", "Rechazada: " + motivo);
        }


        //consultas

        public List<ReservaDTO> ObtenerTodas()
        {
            return _dal.ObtenerTodas();
        }

        public List<ReservaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            return _dal.ObtenerPorPropiedad(idPropiedad);
        }

        public ReservaDTO ObtenerPorId(int idReserva)
        {
            return _dal.ObtenerPorId(idReserva);
        }

        //validaciones
        private void ValidarReserva(ReservaDTO reserva)
        {
            if (reserva.IdArea <= 0)
                throw new Exception("Debe seleccionar un área común.");

            if (reserva.IdPropiedad <= 0)
                throw new Exception("Debe seleccionar una propiedad.");

            if (reserva.IdResidente <= 0)
                throw new Exception("Debe seleccionar un residente.");

            if (reserva.Fecha < DateTime.Today)
                throw new Exception("La fecha de reserva no puede ser en el pasado.");

            if (reserva.HoraFin <= reserva.HoraInicio)
                throw new Exception("La hora de fin debe ser posterior a la hora de inicio.");

            if (reserva.CantidadPersonas <= 0)
                throw new Exception("La cantidad de personas debe ser mayor a cero.");
        }

    }

    }
