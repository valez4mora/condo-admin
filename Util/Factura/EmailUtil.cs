using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Util.Factura
{
    /// <summary>
    /// Utilidad para envío de correos electrónicos.
    /// Envía la factura en formato PDF (adjunto) y XML (adjunto) al destinatario.
    /// Configurar credenciales SMTP en App.config o pasar por parámetros.
    /// </summary>
    public static class EmailUtil
    {
        // ── Configuración SMTP (modificar según el servidor real) ──────
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PUERTO = 587;
        private const string SMTP_USUARIO = "condoadmin@gmail.com";   // cambiar
        private const string SMTP_PASSWORD = "password_app";            // cambiar
        private const string REMITENTE = "Administración Condominio <condoadmin@gmail.com>";

        /// <summary>
        /// Envía la factura por correo con los archivos PDF y XML adjuntos.
        /// </summary>
        /// <param name="destinatario">Email del residente / propietario.</param>
        /// <param name="asunto">Asunto del mensaje.</param>
        /// <param name="cuerpo">Cuerpo HTML del mensaje.</param>
        /// <param name="rutaPdf">Ruta al archivo PDF de la factura (opcional).</param>
        /// <param name="xmlContent">Contenido del XML como string (se adjunta como .xml).</param>
        /// <param name="idFactura">Número de factura, usado para nombrar el adjunto XML.</param>
        public static void EnviarFactura(
            string destinatario,
            string asunto,
            string cuerpo,
            string rutaPdf,
            string xmlContent,
            int idFactura)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
                throw new ArgumentException("El destinatario no puede estar vacío.");

            using (MailMessage mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress(REMITENTE);
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = true;
                mensaje.BodyEncoding = Encoding.UTF8;

                // Adjuntar XML
                if (!string.IsNullOrWhiteSpace(xmlContent))
                {
                    byte[] bytesXml = Encoding.UTF8.GetBytes(xmlContent);
                    System.IO.MemoryStream msXml = new System.IO.MemoryStream(bytesXml);
                    Attachment adjXml = new Attachment(msXml, $"Factura_{idFactura}.xml", "application/xml");
                    mensaje.Attachments.Add(adjXml);
                }

                // Adjuntar PDF si existe
                if (!string.IsNullOrWhiteSpace(rutaPdf) && System.IO.File.Exists(rutaPdf))
                {
                    Attachment adjPdf = new Attachment(rutaPdf, "application/pdf");
                    mensaje.Attachments.Add(adjPdf);
                }

                using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PUERTO))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(SMTP_USUARIO, SMTP_PASSWORD);
                    smtp.Send(mensaje);
                }
            }
        }

        /// <summary>
        /// Construye el cuerpo HTML estándar para el correo de factura.
        /// </summary>
        public static string ConstruirCuerpoFactura(
            string codigoPropiedad,
            int idFactura,
            string fecha,
            string totalColones,
            string totalDolares)
        {
            return $@"
<html>
<body style='font-family:Arial,sans-serif;font-size:14px;'>
  <h2>Factura #{idFactura} — Condominio</h2>
  <p>Estimado residente de la propiedad <strong>{codigoPropiedad}</strong>,</p>
  <p>Se ha emitido una nueva factura con los siguientes datos:</p>
  <table border='1' cellpadding='6' cellspacing='0' style='border-collapse:collapse;'>
    <tr><td><strong>N.° Factura</strong></td><td>{idFactura}</td></tr>
    <tr><td><strong>Fecha</strong></td><td>{fecha}</td></tr>
    <tr><td><strong>Total (₡)</strong></td><td>{totalColones}</td></tr>
    <tr><td><strong>Total ($)</strong></td><td>{totalDolares}</td></tr>
  </table>
  <p>Los archivos adjuntos incluyen la factura en formato <strong>PDF</strong> y <strong>XML</strong>.</p>
  <p>Atentamente,<br/>Administración del Condominio</p>
</body>
</html>";
        }
    }
}
