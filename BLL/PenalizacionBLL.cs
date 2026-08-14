using DAL.DAO;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Factory;

namespace BLL
{
    public class PenalizacionBLL
    {
        private readonly CargoFacturableDAO _cargoDAL;

        public PenalizacionBLL()
        {
            _cargoDAL = new CargoFacturableDAO();
        }

        public CargoFacturableDTO AplicarPenalizacion(PropiedadDTO idPropiedad)
        {
            // Se traen los cargos de esa propiedad
            List<CargoFacturableDTO> cargos = _cargoDAL.ObtenerPorPropiedad(idPropiedad.IdPropiedad);

            // Se busca el cargo de cuota vencido
            CargoFacturableDTO vencido = cargos.FirstOrDefault(c =>
                c.Tipo == "Cuota de Mantenimiento" &&
                c.Estado == "Pendiente" &&
                c.FechaVencimiento < DateTime.Now);

            if (vencido == null)
                throw new Exception("Esta propiedad no tiene cargos vencidos para penalizar.");

            // Evitar duplicaciones en el mismo mes
            bool yaTienePenalizacion = cargos.Any(c =>
                c.Tipo == "Penalizacion" &&
                c.FechaEmision.Month == DateTime.Now.Month &&
                c.FechaEmision.Year == DateTime.Now.Year);

            if (yaTienePenalizacion)
                throw new Exception("Ya se aplicó una penalización este mes para esta propiedad.");

            // Calcular los días de retraso
            int diasAtraso = (DateTime.Now - vencido.FechaVencimiento).Days;

            decimal porcentaje = CalcularPorcentajePenalizacion(diasAtraso);

            if (porcentaje == 0)
                throw new Exception("La propiedad no tiene suficientes días de atraso para penalizar.");

            // Calcular el monto 
            decimal monto = vencido.Total * porcentaje;
            string descripcion = $"Penalización por mora ({diasAtraso} días de atraso)";

            // Factory arma el objeto 
            CargoFacturableDTO penalizacion = GestionFinancieraFactory.CrearPenalizacion(
                idPropiedad.IdPropiedad, monto, descripcion);

            // Se guarda con el DAO instanciado
            bool guardado = _cargoDAL.Registrar(penalizacion);

            if (!guardado)
                throw new Exception("No se pudo guardar la penalización en la base de datos.");

            return penalizacion;
        }

        private decimal CalcularPorcentajePenalizacion(int diasAtraso)
        {
            if (diasAtraso >= 60) return 0.10m;
            if (diasAtraso >= 30) return 0.05m;
            return 0m;
        }
    }
}