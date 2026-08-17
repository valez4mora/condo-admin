using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Util.Factura
{
    public static class PdfFacturaUtil
    {
        private static readonly CultureInfo CulturaCostaRica =
            CultureInfo.GetCultureInfo("es-CR");

        public static string GuardarEnArchivo(
            FacturaDTO factura,
            string carpetaDestino = null)
        {
            if (factura == null)
            {
                throw new ArgumentNullException("factura");
            }

            if (string.IsNullOrWhiteSpace(carpetaDestino))
            {
                carpetaDestino = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "Facturas");
            }

            Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo =
                "Factura_" +
                factura.IdFactura +
                "_" +
                factura.Fecha.ToString("yyyyMMdd") +
                ".pdf";

            string ruta = Path.Combine(
                carpetaDestino,
                nombreArchivo);

            List<string> lineas = ConstruirLineas(factura);

            EscribirPdf(ruta, lineas);

            return ruta;
        }

        private static List<string> ConstruirLineas(
            FacturaDTO factura)
        {
            List<string> lineas = new List<string>();

            lineas.Add("ADMINISTRACION DEL CONDOMINIO");
            lineas.Add("Factura No. " + factura.IdFactura);
            lineas.Add(
                "Fecha: " +
                factura.Fecha.ToString("dd/MM/yyyy HH:mm"));
            lineas.Add(
                "Propiedad: " +
                (factura.CodigoPropiedad ?? string.Empty));
            lineas.Add(
                "Estado: " +
                (factura.Estado ?? "Emitida"));

            lineas.Add(
                "-----------------------------------------------");

            if (factura.Detalles != null &&
                factura.Detalles.Count > 0)
            {
                foreach (DetalleFacturaDTO detalle in factura.Detalles)
                {
                    if (detalle == null)
                    {
                        continue;
                    }

                    string descripcion =
                        string.IsNullOrWhiteSpace(
                            detalle.DescripcionCargo)
                            ? "Cargo"
                            : detalle.DescripcionCargo;

                    lineas.Add(
                        descripcion +
                        "   CRC " +
                        detalle.SubTotal.ToString(
                            "N2",
                            CulturaCostaRica));
                }
            }
            else
            {
                lineas.Add("Sin detalles registrados.");
            }

            lineas.Add(
                "-----------------------------------------------");

            lineas.Add(
                "Total colones: CRC " +
                factura.TotalColones.ToString(
                    "N2",
                    CulturaCostaRica));

            lineas.Add(
                "Tipo de cambio de referencia: CRC " +
                factura.TipoCambio.ToString(
                    "N4",
                    CulturaCostaRica) +
                " por USD");

            lineas.Add(
                "Total dolares: USD " +
                factura.TotalDolares.ToString(
                    "N2",
                    CulturaCostaRica));

            lineas.Add(
                "Saldo pendiente: CRC " +
                factura.SaldoPendiente.ToString(
                    "N2",
                    CulturaCostaRica));

            lineas.Add(string.Empty);
            lineas.Add(
                "El tipo de cambio mostrado es una referencia externa.");

            return lineas;
        }

        private static void EscribirPdf(
            string ruta,
            List<string> lineas)
        {
            StringBuilder contenido =
                new StringBuilder();

            contenido.Append("BT\n");
            contenido.Append("/F1 11 Tf\n");
            contenido.Append("50 790 Td\n");

            for (int i = 0; i < lineas.Count; i++)
            {
                if (i > 0)
                {
                    contenido.Append("0 -22 Td\n");
                }

                contenido
                    .Append("(")
                    .Append(Escapar(lineas[i]))
                    .Append(") Tj\n");
            }

            contenido.Append("ET");

            byte[] stream =
                Encoding.ASCII.GetBytes(contenido.ToString());

            List<string> objetos = new List<string>
            {
                "<< /Type /Catalog /Pages 2 0 R >>",

                "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",

                "<< /Type /Page /Parent 2 0 R " +
                "/MediaBox [0 0 612 842] " +
                "/Resources << /Font << /F1 5 0 R >> >> " +
                "/Contents 4 0 R >>",

                "<< /Length " + stream.Length +
                " >>\nstream\n" +
                contenido +
                "\nendstream",

                "<< /Type /Font /Subtype /Type1 " +
                "/BaseFont /Helvetica >>"
            };

            using (FileStream archivo = new FileStream(
                ruta,
                FileMode.Create,
                FileAccess.Write))
            using (StreamWriter escritor = new StreamWriter(
                archivo,
                Encoding.ASCII))
            {
                escritor.NewLine = "\n";

                escritor.Write("%PDF-1.4\n");
                escritor.Flush();

                List<long> posiciones =
                    new List<long> { 0 };

                for (int i = 0; i < objetos.Count; i++)
                {
                    posiciones.Add(archivo.Position);

                    escritor.Write(
                        (i + 1) +
                        " 0 obj\n" +
                        objetos[i] +
                        "\nendobj\n");

                    escritor.Flush();
                }

                long posicionXref = archivo.Position;

                escritor.Write(
                    "xref\n0 " +
                    (objetos.Count + 1) +
                    "\n");

                escritor.Write(
                    "0000000000 65535 f \n");

                for (int i = 1; i < posiciones.Count; i++)
                {
                    escritor.Write(
                        posiciones[i].ToString("0000000000") +
                        " 00000 n \n");
                }

                escritor.Write(
                    "trailer\n" +
                    "<< /Size " +
                    (objetos.Count + 1) +
                    " /Root 1 0 R >>\n" +
                    "startxref\n" +
                    posicionXref +
                    "\n%%EOF");

                escritor.Flush();
            }
        }

        private static string Escapar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return string.Empty;
            }

            string normalizado =
                texto.Normalize(NormalizationForm.FormD);

            StringBuilder resultado =
                new StringBuilder();

            foreach (char caracter in normalizado)
            {
                UnicodeCategory categoria =
                    CharUnicodeInfo.GetUnicodeCategory(caracter);

                if (categoria != UnicodeCategory.NonSpacingMark)
                {
                    resultado.Append(caracter);
                }
            }

            return resultado
                .ToString()
                .Normalize(NormalizationForm.FormC)
                .Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }
    }
}