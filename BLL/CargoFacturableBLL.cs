using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Util.Enumeraciones;

namespace BLL
{
    /// Lógica de negocio para cargos facturables.
    /// Maneja la generación automática de cuotas, el registro manual de
    /// multas / cuotas extraordinarias / reservas, y el CRUD completo.
    public class CargoFacturableBLL
    {
        private readonly ICargoFacturableDAL _dal = new CargoFacturableDAO();

        // Tasa de IVA vigente (13 %)
        private const decimal PORCENTAJE_IVA = 0.13m;

        // GENERACIÓN AUTOMÁTICA — Cuota de mantenimiento
        // Cuota = (Área × TarifaM2) + CargoFijo
        /// Calcula y persiste la cuota de mantenimiento ordinaria para una propiedad.
        /// Usa la Factory para construir el DTO con IVA aplicado.
        public CargoFacturableDTO GenerarCuotaOrdinaria(PropiedadDTO propiedad)
        {
            ValidarPropiedad(propiedad);

            DateTime hoy = DateTime.Today;
            bool yaExiste = _dal.ObtenerPorPropiedad(propiedad.IdPropiedad).Any(c =>
                c.Tipo == TipoCargo.CuotaMantenimiento.ToString() &&
                c.FechaEmision.Year == hoy.Year &&
                c.FechaEmision.Month == hoy.Month &&
                c.Estado != "Anulado");
            if (yaExiste)
                throw new Exception("Ya existe una cuota de mantenimiento para esta propiedad en " +
                    hoy.ToString("MMMM yyyy") + ".");

            decimal montoBase = decimal.Round(
                (propiedad.Area * propiedad.TarifaMetro) + propiedad.CargoFijo,
                2,
                MidpointRounding.AwayFromZero);

            if (montoBase <= 0)
                throw new Exception("La cuota calculada debe ser mayor a cero.");

            propiedad.CuotaMantenimiento = montoBase;

            CargoFacturableDTO cargo =
                GestionFinancieraFactory.CrearCuotaMantenimiento(propiedad.IdPropiedad, montoBase);

            if (!_dal.Registrar(cargo))
                throw new Exception("No se pudo guardar la cuota en la base de datos.");

            // Registra el aporte histórico del 10 % solicitado por el proyecto.
            new FondoReservaBLL().RegistrarFondo(propiedad, montoBase);

            return cargo;
        }

        // REGISTRO MANUAL — Multa / Cuota Extraordinaria / Reserva / etc.
        /// Registra un cargo facturable creado manualmente por el administrador.
        /// Aplica IVA solo a CuotaMantenimiento y CuotaExtraordinaria.
        public CargoFacturableDTO RegistrarManual(CargoFacturableDTO cargo)
        {
            ValidarCargoManual(cargo);

            // Recalcular IVA según tipo
            cargo.IVA = AplicaIVA(cargo.Tipo) ? cargo.MontoBase * PORCENTAJE_IVA : 0m;
            cargo.Total = cargo.MontoBase + cargo.IVA;

            // Valores por defecto si no vienen del formulario
            if (cargo.FechaEmision == DateTime.MinValue)
                cargo.FechaEmision = DateTime.Now;

            if (cargo.FechaVencimiento == DateTime.MinValue)
                cargo.FechaVencimiento = DateTime.Now.AddDays(30);

            if (string.IsNullOrWhiteSpace(cargo.Estado))
                cargo.Estado = "Pendiente";

            if (!_dal.Registrar(cargo))
                throw new Exception("No se pudo guardar el cargo en la base de datos.");

            return cargo;
        }

        // CRUD
        public bool Modificar(CargoFacturableDTO cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException("El cargo no puede ser nulo.");

            if (cargo.IdCargo <= 0)
                throw new Exception("Debe indicar un cargo válido para modificar.");

            CargoFacturableDTO existente = _dal.ObtenerPorId(cargo.IdCargo);
            if (existente == null)
                throw new Exception("No se encontró el cargo indicado.");

            if (existente.Estado == "Pagado")
                throw new Exception("No se puede modificar un cargo que ya fue pagado.");

            ValidarCargoManual(cargo);

            // Recalcular IVA y total
            cargo.IVA = AplicaIVA(cargo.Tipo) ? cargo.MontoBase * PORCENTAJE_IVA : 0m;
            cargo.Total = cargo.MontoBase + cargo.IVA;

            return _dal.Modificar(cargo);
        }

        public bool Eliminar(int idCargo)
        {
            if (idCargo <= 0)
                throw new Exception("Debe indicar un cargo válido para eliminar.");

            CargoFacturableDTO existente = _dal.ObtenerPorId(idCargo);
            if (existente == null)
                throw new Exception("No se encontró el cargo indicado.");

            if (existente.Estado == "Pagado")
                throw new Exception("No se puede eliminar un cargo que ya fue pagado.");

            return _dal.Eliminar(idCargo);
        }

        ///Marca un cargo como pagado. Solo aplica si está en estado Pendiente.
        public bool MarcarComoPagado(int idCargo)
        {
            if (idCargo <= 0)
                throw new Exception("Debe indicar un cargo válido.");

            CargoFacturableDTO existente = _dal.ObtenerPorId(idCargo);
            if (existente == null)
                throw new Exception("No se encontró el cargo indicado.");

            if (existente.Estado == "Pagado")
                throw new Exception("El cargo ya se encuentra pagado.");

            return _dal.MarcarComoPagado(idCargo);
        }

        // CONSULTAS
        public CargoFacturableDTO ObtenerPorId(int idCargo)
        {
            if (idCargo <= 0)
                throw new Exception("Debe indicar un Id de cargo válido.");

            return _dal.ObtenerPorId(idCargo);
        }

        public List<CargoFacturableDTO> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public List<CargoFacturableDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new Exception("Debe indicar una propiedad válida.");

            return _dal.ObtenerPorPropiedad(idPropiedad);
        }

        ///Devuelve solo los cargos pendientes de una propiedad.
        public List<CargoFacturableDTO> ObtenerPendientesPorPropiedad(int idPropiedad)
        {
            return ObtenerPorPropiedad(idPropiedad)
                .Where(c => c.Estado == "Pendiente")
                .ToList();
        }

        /// Devuelve los cargos vencidos (Pendiente y FechaVencimiento pasada).
        /// Se usa para calcular morosidad e intereses.
        public List<CargoFacturableDTO> ObtenerVencidosPorPropiedad(int idPropiedad)
        {
            return ObtenerPorPropiedad(idPropiedad)
                .Where(c => c.Estado == "Pendiente" && c.FechaVencimiento < DateTime.Now)
                .ToList();
        }

        // HELPERS PRIVADOS
        private void ValidarPropiedad(PropiedadDTO propiedad)
        {
            if (propiedad == null)
                throw new Exception("Debe indicar una propiedad válida.");

            if (propiedad.Area <= 0)
                throw new Exception("La propiedad no tiene un área válida.");

            if (propiedad.TarifaMetro <= 0)
                throw new Exception("La propiedad no tiene tarifa configurada.");

            if (propiedad.CargoFijo < 0)
                throw new Exception("La propiedad tiene un cargo fijo inválido.");

            if (propiedad.IdPropiedad <= 0)
                throw new Exception("La propiedad no tiene un Id válido.");
        }

        private void ValidarCargoManual(CargoFacturableDTO cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException("El cargo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(cargo.Descripcion))
                throw new Exception("La descripción del cargo es obligatoria.");

            if (string.IsNullOrWhiteSpace(cargo.Tipo))
                throw new Exception("Debe indicar el tipo de cargo.");

            if (cargo.MontoBase <= 0)
                throw new Exception("El monto base debe ser mayor a cero.");

            if (cargo.IdPropiedad <= 0)
                throw new Exception("Debe asociar el cargo a una propiedad.");

            if (cargo.FechaVencimiento != DateTime.MinValue &&
                cargo.FechaVencimiento <= cargo.FechaEmision)
                throw new Exception("La fecha de vencimiento debe ser posterior a la fecha de emisión.");
        }

        /// Determina si el tipo de cargo tiene IVA (13 %) según el reglamento del proyecto.
        /// Multas, penalizaciones, fondo de reserva e intereses no llevan IVA.
        private bool AplicaIVA(string tipo)
        {
            return tipo == TipoCargo.CuotaMantenimiento.ToString() ||
                   tipo == TipoCargo.CuotaExtraordinaria.ToString();
        }
    }
}
