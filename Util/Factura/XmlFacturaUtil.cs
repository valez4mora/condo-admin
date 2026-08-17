using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Xml.Linq;
using DTO;

namespace Util.Factura
{
    public static class XmlFacturaUtil
    {
        /// Genera el XML completo de la factura (encabezado + detalle).
        /// Retorna el XML como string para almacenar en BD o enviar por correo.
        public static string GenerarXml(FacturaDTO factura)
        {
            if (factura == null)
                throw new ArgumentNullException("factura", "La factura no puede ser nula.");

            XDocument doc = new XDocument(
                new XElement("Factura",

                    // ── ENCABEZADO ─────────────────────────────────────────
                    new XElement("Encabezado",
                        new XElement("IdFactura", factura.IdFactura),
                        new XElement("Fecha", factura.Fecha.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement("CodigoPropiedad", factura.CodigoPropiedad ?? ""),
                        new XElement("IdPropiedad", factura.IdPropiedad),
                        new XElement("TotalColones", factura.TotalColones.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("TotalDolares", factura.TotalDolares.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("TipoCambio", factura.TipoCambio.ToString("F4", CultureInfo.InvariantCulture)),
                        new XElement("TotalPagado", factura.TotalPagado.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("SaldoPendiente", factura.SaldoPendiente.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("Estado", factura.Estado ?? "Emitida")
                    ),

                    // ── DETALLE ────────────────────────────────────────────
                    GenerarNodoDetalle(factura)
                )
            );

            // SQL Server recibe una cadena Unicode. No se incluye una declaración
            // encoding="UTF-8" porque solo corresponde cuando se escriben bytes.
            return doc.ToString();
        }

        /// Guarda el XML en un archivo físico (para descarga / impresión).
        /// Retorna la ruta del archivo generado.
        public static string GuardarEnArchivo(FacturaDTO factura, string carpetaDestino = null)
        {
            string xml = GenerarXml(factura);

            if (string.IsNullOrWhiteSpace(carpetaDestino))
                carpetaDestino = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Facturas");

            Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo = $"Factura_{factura.IdFactura}_{factura.Fecha:yyyyMMdd}.xml";
            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            File.WriteAllText(rutaCompleta, xml, Encoding.UTF8);
            return rutaCompleta;
        }

        // ── HELPERS PRIVADOS ──────────────────────────────────────────────

        private static XElement GenerarNodoDetalle(FacturaDTO factura)
        {
            XElement detalle = new XElement("Detalle");

            if (factura.Detalles != null)
            {
                foreach (DetalleFacturaDTO d in factura.Detalles)
                {
                    detalle.Add(new XElement("Linea",
                        new XElement("IdCargo", d.IdCargo),
                        new XElement("Descripcion", d.DescripcionCargo ?? ""),
                        new XElement("Tipo", d.TipoCargo ?? ""),
                        new XElement("MontoBase", d.MontoBase.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("IVA", d.IVA.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("Cantidad", d.Cantidad),
                        new XElement("PrecioUnitario", d.Precio.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("SubTotal", d.SubTotal.ToString("F2", CultureInfo.InvariantCulture))
                    ));
                }
            }

            return detalle;
        }

    }
}
