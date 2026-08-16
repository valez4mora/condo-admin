using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BitacoraBLL
    {
        private readonly IBitacoraDAL dal;
        public BitacoraBLL() : this(new BitacoraDAO()) { }
        public BitacoraBLL(IBitacoraDAL dal) { this.dal = dal ?? throw new ArgumentNullException("dal"); }

        public bool Registrar(int idUsuario, string evento)
        {
            if (idUsuario <= 0) throw new Exception("Debe indicar el usuario que realiza la acción.");
            if (string.IsNullOrWhiteSpace(evento)) throw new Exception("El evento de bitácora es obligatorio.");
            evento = evento.Trim();
            if (evento.Length > 250) throw new Exception("El evento no puede superar 250 caracteres.");
            return dal.Registrar(new BitacoraDTO { IdUsuario = idUsuario, Evento = evento, Fecha = DateTime.Now });
        }

        public List<BitacoraDTO> ObtenerTodas() { return dal.ObtenerTodas(); }

        public List<BitacoraDTO> ObtenerPorFecha(DateTime desde, DateTime hasta)
        {
            desde = desde.Date; hasta = hasta.Date;
            if (desde > hasta) throw new Exception("La fecha inicial no puede ser posterior a la fecha final.");
            if ((hasta - desde).TotalDays > 366) throw new Exception("El rango de consulta no puede superar un año.");
            return dal.ObtenerPorFecha(desde, hasta);
        }
    }
}
