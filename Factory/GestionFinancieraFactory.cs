using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Factory
{
    /// <summary>
    /// Centraliza la creación de los distintos cargos financieros
    /// utilizados por el sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase implementa el patrón Factory. Se encarga de construir
    /// objetos <see cref="CargoFacturableDTO"/> correctamente configurados
    /// según el tipo de operación financiera solicitada.
    /// </remarks>
    public class GestionFinancieraFactory
    {
        /// <summary>
        /// Porcentaje de IVA aplicado a las cuotas de mantenimiento.
        /// </summary>
        private const decimal PORCENTAJE_IVA = 0.13m;

        // ---------- Cuota de mantenimiento ----------
        // Cuota = (Area x Tarifa) + CargoFijo

        /// <summary>
        /// Crea un cargo correspondiente a una cuota ordinaria
        /// de mantenimiento.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad a la que se asignará la cuota.
        /// </param>
        /// <param name="montoBase">
        /// Monto de la cuota antes de aplicar el IVA.
        /// </param>
        /// <returns>
        /// Cargo facturable de tipo cuota de mantenimiento, con el IVA
        /// y el total calculados.
        /// </returns>
        public static CargoFacturableDTO CrearCuotaMantenimiento(
            int idPropiedad,
            decimal montoBase)
        {
            decimal baseRedondeada = decimal.Round(
                montoBase, 2, MidpointRounding.AwayFromZero);

            decimal iva = decimal.Round(
                baseRedondeada * PORCENTAJE_IVA,
                2,
                MidpointRounding.AwayFromZero);

            decimal total = baseRedondeada + iva;

            return new CargoFacturableDTO // se crea el objeto
            {
                Descripcion = "Cuota de mantenimiento",
                Tipo = "CuotaMantenimiento",
                MontoBase = baseRedondeada,
                IVA = iva,
                Total = total,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(30),
                Estado = "Pendiente",
                IdPropiedad = idPropiedad
            };
        }

        // ---------- Fondo de reserva ----------
        // FondoReserva = Cuota x 10%

        /// <summary>
        /// Crea un cargo correspondiente al aporte del fondo de reserva.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad a la que se asignará el aporte.
        /// </param>
        /// <param name="montoCuota">
        /// Monto de la cuota utilizado como base para calcular el aporte.
        /// </param>
        /// <returns>
        /// Cargo facturable de tipo fondo de reserva, equivalente al
        /// diez por ciento del monto de la cuota.
        /// </returns>
        public static CargoFacturableDTO CrearFondoReserva(
            int idPropiedad,
            decimal montoCuota)
        {
            decimal montoBase = montoCuota * 0.10m;

            return new CargoFacturableDTO
            {
                Descripcion = "Fondo de reserva",
                Tipo = "FondoReserva",
                MontoBase = montoBase,
                IVA = 0,
                Total = montoBase,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(30),
                Estado = "Pendiente",
                IdPropiedad = idPropiedad
            };
        }

        // ---------- Interés por mora ----------
        // Interes = Saldo x Tasa x Meses

        /// <summary>
        /// Crea un cargo correspondiente al interés generado por morosidad.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad que mantiene la deuda.
        /// </param>
        /// <param name="saldo">
        /// Saldo pendiente sobre el que se calculará el interés.
        /// </param>
        /// <param name="tasa">
        /// Tasa de interés que se aplicará al saldo pendiente.
        /// </param>
        /// <param name="meses">
        /// Cantidad de meses de atraso.
        /// </param>
        /// <returns>
        /// Cargo facturable de tipo interés por mora.
        /// </returns>
        public static CargoFacturableDTO CrearInteresMora(
            int idPropiedad,
            decimal saldo,
            decimal tasa,
            int meses)
        {
            decimal montoBase = saldo * tasa * meses;

            return new CargoFacturableDTO
            {
                Descripcion = $"Interés por mora ({meses} mes(es))",
                Tipo = "InteresMora",
                MontoBase = montoBase,
                IVA = 0,
                Total = montoBase,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(15),
                Estado = "Pendiente",
                IdPropiedad = idPropiedad
            };
        }

        // ---------- Penalización ----------

        /// <summary>
        /// Crea un cargo correspondiente a una penalización.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad a la que se aplicará la penalización.
        /// </param>
        /// <param name="monto">
        /// Monto total de la penalización.
        /// </param>
        /// <param name="descripcion">
        /// Descripción que explica el motivo de la penalización.
        /// </param>
        /// <returns>
        /// Cargo facturable de tipo penalización.
        /// </returns>
        public static CargoFacturableDTO CrearPenalizacion(
            int idPropiedad,
            decimal monto,
            string descripcion)
        {
            return new CargoFacturableDTO
            {
                Descripcion = descripcion,
                Tipo = "Penalizacion",
                MontoBase = monto,
                IVA = 0,
                Total = monto,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(15),
                Estado = "Pendiente",
                IdPropiedad = idPropiedad
            };
        }
    }
}