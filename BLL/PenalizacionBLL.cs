using DAL.DAO;
using DTO;
using Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PenalizacionBLL
    {
        private readonly CargoFacturableDAO cargoDAL = new CargoFacturableDAO();

        public CargoFacturableDTO AplicarPenalizacion(PropiedadDTO propiedad)
        {
            if (propiedad == null || propiedad.IdPropiedad <= 0)
                throw new ArgumentException("Debe indicar una propiedad válida.");

            List<CargoFacturableDTO> cargos = cargoDAL.ObtenerPorPropiedad(propiedad.IdPropiedad);
            CargoFacturableDTO vencido = cargos
                .Where(c => c.Tipo == "CuotaMantenimiento" &&
                    (c.Estado == "Pendiente" || c.Estado == "Vencido") &&
                    c.FechaVencimiento.Date < DateTime.Today)
                .OrderBy(c => c.FechaVencimiento)
                .FirstOrDefault();

            if (vencido == null)
                throw new Exception("Esta propiedad no tiene cuotas vencidas para penalizar.");

            int diasAtraso = (DateTime.Today - vencido.FechaVencimiento.Date).Days;
            decimal porcentaje = diasAtraso > 60 ? 0.10m : diasAtraso > 30 ? 0.05m : 0m;
            if (porcentaje == 0)
                throw new Exception("La deuda todavía no supera los 30 días de atraso.");

            bool yaAplicada = cargos.Any(c => c.Tipo == "Penalizacion" &&
                c.FechaEmision.Month == DateTime.Today.Month &&
                c.FechaEmision.Year == DateTime.Today.Year);
            if (yaAplicada)
                throw new Exception("Ya existe una penalización para esta propiedad en el mes actual.");

            decimal monto = Math.Round(vencido.Total * porcentaje, 2);
            CargoFacturableDTO penalizacion = GestionFinancieraFactory.CrearPenalizacion(
                propiedad.IdPropiedad, monto,
                "Penalización por mora (" + diasAtraso + " días, " +
                (porcentaje * 100).ToString("N0") + "%)");

            if (!cargoDAL.Registrar(penalizacion))
                throw new Exception("No se pudo registrar la penalización.");
            return penalizacion;
        }
    }
}
