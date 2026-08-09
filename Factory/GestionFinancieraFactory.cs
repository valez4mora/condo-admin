using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Factory
{
    public class GestionFinancieraFactory
    {
        private const decimal PORCENTAJE_IVA = 0.13m;

        // ---------- Cuota de mantenimiento ----------
        // Cuota = (Area x Tarifa) + CargoFijo
        public static CargoFacturableDTO CrearCuotaMantenimiento(int idPropiedad, decimal montoBase)
        {
            decimal iva = montoBase * PORCENTAJE_IVA;
            decimal total = montoBase + iva;

            return new CargoFacturableDTO // se crea el objeto
            {
                Descripcion = "Cuota de mantenimiento",
                Tipo = "Cuota de mantenimiento",
                MontoBase = montoBase,
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
        public static CargoFacturableDTO CrearFondoReserva(int idPropiedad, decimal montoCuota)
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
        public static CargoFacturableDTO CrearInteresMora(int idPropiedad, decimal saldo, decimal tasa, int meses)
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

        // --------- Penalizacion --------------
        public static CargoFacturableDTO CrearPenalizacion(int idPropiedad, decimal monto, string descripcion)
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
