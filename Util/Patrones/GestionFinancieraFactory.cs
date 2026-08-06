using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Patrones
{
    public class GestionFinancieraFactory
    {
        private const decimal PORCENTAJE_IVA = 0.3m; 

        // ---------- Cuota de mantenimiento ----------
        // Cuota = (Area x Tarifa) + CargoFijo
        public static CargoFacturableDTO CrearCuotaMantenimiento(int idPropiedad, decimal area, decimal tarifa, decimal cargoFijo)
        {
            decimal montoBase = (area * tarifa) + cargoFijo;
            decimal iva = montoBase * PORCENTAJE_IVA;

            return new CargoFacturableDTO
            {
                Descripcion = "Cuota de mantenimiento",
                Tipo = "CuotaMantenimiento",
                MontoBase = montoBase,
                IVA = iva,
                Total = montoBase + iva,
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

        // ---------- Penalización ----------
        // 30 dias -> 5% | 60 dias -> 10% | 90 dias -> restricción de reservas (sin cargo adicional)
        public static CargoFacturableDTO CrearPenalizacion(int idPropiedad, int diasAtraso, decimal montoBase)
        {
            decimal porcentaje;
            string descripcion;

            if (diasAtraso >= 90)
            {
                porcentaje = 0m;
                descripcion = "Penalización: restricción de reservas (90+ días de atraso)";
            }
            else if (diasAtraso >= 60)
            {
                porcentaje = 0.10m;
                descripcion = "Penalización por mora (60 días)";
            }
            else if (diasAtraso >= 30)
            {
                porcentaje = 0.05m;
                descripcion = "Penalización por mora (30 días)";
            }
            else
            {
                porcentaje = 0m;
                descripcion = "Sin penalización";
            }

            decimal monto = montoBase * porcentaje;

            return new CargoFacturableDTO
            {
                Descripcion = descripcion,
                Tipo = "Penalizacion",
                MontoBase = monto,
                IVA = 0,
                Total = monto,
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(10),
                Estado = "Pendiente",
                IdPropiedad = idPropiedad
            };
        }

        // ---------- Índice de riesgo ----------
        // Clasifica según meses de mora: Bajo / Medio / Alto / Crítico
        public static string ClasificarRiesgo(int mesesMora)
        {
            if (mesesMora == 0) return "Bajo";
            if (mesesMora <= 2) return "Medio";
            if (mesesMora <= 3) return "Alto";
            return "Crítico";
        }

        // ---------- Cuota de Mantenimiento ----------
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
    }
}