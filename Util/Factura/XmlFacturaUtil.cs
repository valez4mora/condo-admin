using System;
using System.IO;
using System.Text;
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
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("Factura",

                    // ── ENCABEZADO ─────────────────────────────────────────
                    new XElement("Encabezado",
                        new XElement("IdFactura", factura.IdFactura),
                        new XElement("Fecha", factura.Fecha.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement("CodigoPropiedad", factura.CodigoPropiedad ?? ""),
                        new XElement("IdPropiedad", factura.IdPropiedad),
                        new XElement("TotalColones", factura.TotalColones.ToString("F2")),
                        new XElement("TotalDolares", factura.TotalDolares.ToString("F2")),
                        new XElement("TipoCambio", factura.TipoCambio.ToString("F4")),
                        new XElement("TotalPagado", factura.TotalPagado.ToString("F2")),
                        new XElement("SaldoPendiente", factura.SaldoPendiente.ToString("F2")),
                        new XElement("Estado", factura.Estado ?? "Emitida")
                    ),

                    // ── DETALLE ────────────────────────────────────────────
                    GenerarNodoDetalle(factura)
                )
            );

            // Se serializa a string con encoding UTF-8
            using (StringWriter sw = new StringWriterUtf8())
            {
                doc.Save(sw);
                return sw.ToString();
            }
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
                        new XElement("MontoBase", d.MontoBase.ToString("F2")),
                        new XElement("IVA", d.IVA.ToString("F2")),
                        new XElement("Cantidad", d.Cantidad),
                        new XElement("PrecioUnitario", d.Precio.ToString("F2")),
                        new XElement("SubTotal", d.SubTotal.ToString("F2"))
                    ));
                }
            }

            return detalle;
        }

        /// StringWriter que fuerza el encoding UTF-8 en la declaración XML.
        private class StringWriterUtf8 : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
