using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Util.Factura
{
    /// <summary>Genera un PDF básico y portable sin depender de paquetes externos.</summary>
    public static class PdfFacturaUtil
    {
        public static string GuardarEnArchivo(FacturaDTO factura, string carpetaDestino = null)
        {
            if (factura == null) throw new ArgumentNullException("factura");
            if (string.IsNullOrWhiteSpace(carpetaDestino))
                carpetaDestino = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Facturas");

            Directory.CreateDirectory(carpetaDestino);
            string ruta = Path.Combine(carpetaDestino,
                "Factura_" + factura.IdFactura + "_" + factura.Fecha.ToString("yyyyMMdd") + ".pdf");

            List<string> lineas = new List<string>();
            lineas.Add("ADMINISTRACION DEL CONDOMINIO");
            lineas.Add("Factura No. " + factura.IdFactura);
            lineas.Add("Fecha: " + factura.Fecha.ToString("dd/MM/yyyy HH:mm"));
            lineas.Add("Propiedad: " + (factura.CodigoPropiedad ?? ""));
            lineas.Add("Estado: " + (factura.Estado ?? "Emitida"));
            lineas.Add("-----------------------------------------------");
            if (factura.Detalles != null)
            {
                foreach (DetalleFacturaDTO d in factura.Detalles)
                    lineas.Add((d.DescripcionCargo ?? "Cargo") + "   CRC " +
                        d.SubTotal.ToString("N2", CultureInfo.InvariantCulture));
            }
            lineas.Add("-----------------------------------------------");
            lineas.Add("Total colones: CRC " + factura.TotalColones.ToString("N2"));
            lineas.Add("Tipo de cambio venta: " + factura.TipoCambio.ToString("N4"));
            lineas.Add("Total dolares: USD " + factura.TotalDolares.ToString("N2"));
            lineas.Add("Saldo pendiente: CRC " + factura.SaldoPendiente.ToString("N2"));

            EscribirPdf(ruta, lineas);
            return ruta;
        }

        private static void EscribirPdf(string ruta, List<string> lineas)
        {
            StringBuilder contenido = new StringBuilder("BT\n/F1 11 Tf\n50 790 Td\n");
            for (int i = 0; i < lineas.Count; i++)
            {
                if (i > 0) contenido.Append("0 -22 Td\n");
                contenido.Append("(").Append(Escapar(lineas[i])).Append(") Tj\n");
            }
            contenido.Append("ET");
            byte[] stream = Encoding.ASCII.GetBytes(contenido.ToString());

            List<string> objetos = new List<string>
            {
                "<< /Type /Catalog /Pages 2 0 R >>",
                "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",
                "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 842] /Resources << /Font << /F1 5 0 R >> >> /Contents 4 0 R >>",
                "<< /Length " + stream.Length + " >>\nstream\n" + contenido + "\nendstream",
                "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>"
            };

            using (FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
            {
                sw.NewLine = "\n";
                sw.Write("%PDF-1.4\n"); sw.Flush();
                List<long> offsets = new List<long> { 0 };
                for (int i = 0; i < objetos.Count; i++)
                {
                    offsets.Add(fs.Position);
                    sw.Write((i + 1) + " 0 obj\n" + objetos[i] + "\nendobj\n"); sw.Flush();
                }
                long xref = fs.Position;
                sw.Write("xref\n0 " + (objetos.Count + 1) + "\n");
                sw.Write("0000000000 65535 f \n");
                for (int i = 1; i < offsets.Count; i++)
                    sw.Write(offsets[i].ToString("0000000000") + " 00000 n \n");
                sw.Write("trailer\n<< /Size " + (objetos.Count + 1) + " /Root 1 0 R >>\nstartxref\n" + xref + "\n%%EOF");
            }
        }

        private static string Escapar(string texto)
        {
            return texto.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)")
                .Normalize(NormalizationForm.FormD);
        }
    }
}
