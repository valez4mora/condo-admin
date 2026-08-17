using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Util.Factura
{
    /// <summary>
    /// Proporciona operaciones para construir y enviar facturas por correo
    /// electrónico.
    /// </summary>
    /// <remarks>
    /// Esta clase utiliza la configuración SMTP almacenada en el archivo
    /// de configuración de la aplicación.
    ///
    /// Puede ejecutarse en modo de simulación para validar el proceso de
    /// facturación sin enviar realmente el correo electrónico.
    /// </remarks>
    public static class EmailUtil
    {
        /// <summary>
        /// Dirección del servidor SMTP utilizado para enviar los correos.
        /// </summary>
        private const string SMTP_HOST = "smtp.gmail.com";

        /// <summary>
        /// Puerto SMTP utilizado para establecer una conexión segura mediante
        /// TLS con el servidor de Gmail.
        /// </summary>
        private const int SMTP_PUERTO = 587;

        /// <summary>
        /// Envía una factura por correo electrónico con sus archivos PDF y XML
        /// adjuntos.
        /// </summary>
        /// <param name="destinatario">
        /// Dirección de correo electrónico del residente o propietario que
        /// recibirá la factura.
        /// </param>
        /// <param name="asunto">
        /// Asunto que se mostrará en el mensaje de correo.
        /// </param>
        /// <param name="cuerpo">
        /// Contenido HTML que se utilizará como cuerpo del mensaje.
        /// </param>
        /// <param name="rutaPdf">
        /// Ruta completa del archivo PDF que se adjuntará. Puede ser nula o
        /// vacía cuando no exista un documento PDF.
        /// </param>
        /// <param name="xmlContent">
        /// Contenido completo del XML de la factura. Este contenido se
        /// convierte en un archivo adjunto con extensión XML.
        /// </param>
        /// <param name="idFactura">
        /// Identificador de la factura, utilizado para construir el nombre
        /// del archivo XML adjunto.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el destinatario está vacío o no posee un formato
        /// válido de correo electrónico.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Se produce cuando no se configuraron el usuario o la contraseña
        /// SMTP requeridos para enviar el mensaje.
        /// </exception>
        /// <exception cref="SmtpException">
        /// Se produce cuando el servidor SMTP rechaza el mensaje o no puede
        /// completar el envío.
        /// </exception>
        /// <remarks>
        /// Las claves <c>SimularCorreo</c>, <c>SmtpUsuario</c>,
        /// <c>SmtpPassword</c> y <c>SmtpRemitente</c> deben configurarse en
        /// el archivo <c>App.config</c>.
        ///
        /// Cuando <c>SimularCorreo</c> tiene un valor diferente de
        /// <c>false</c>, el método valida el destinatario pero no establece
        /// una conexión con el servidor SMTP.
        /// </remarks>
        public static void EnviarFactura(
            string destinatario,
            string asunto,
            string cuerpo,
            string rutaPdf,
            string xmlContent,
            int idFactura)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
            {
                throw new ArgumentException(
                    "El destinatario no puede estar vacío.",
                    "destinatario");
            }

            /*
             * Intenta construir la dirección antes de continuar.
             * MailAddress genera una excepción si el formato es inválido.
             */
            new MailAddress(destinatario);

            /*
             * El modo de simulación permite probar la generación de facturas
             * sin enviar correos reales. Solamente se desactiva cuando la
             * configuración contiene explícitamente el valor "false".
             */
            bool simular = !string.Equals(
                ConfigurationManager.AppSettings["SimularCorreo"],
                "false",
                StringComparison.OrdinalIgnoreCase);

            if (simular)
            {
                return;
            }

            // Obtiene las credenciales y el remitente desde App.config.
            string usuario =
                ConfigurationManager.AppSettings["SmtpUsuario"];

            string password =
                ConfigurationManager.AppSettings["SmtpPassword"];

            string remitente =
                ConfigurationManager.AppSettings["SmtpRemitente"];

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException(
                    "Falta configurar SmtpUsuario y SmtpPassword.");
            }

            /*
             * Si no se configuró un remitente diferente, se utiliza como
             * remitente la misma cuenta empleada para autenticarse.
             */
            if (string.IsNullOrWhiteSpace(remitente))
            {
                remitente = usuario;
            }

            using (MailMessage mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress(remitente);
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto ?? string.Empty;
                mensaje.Body = cuerpo ?? string.Empty;
                mensaje.IsBodyHtml = true;
                mensaje.BodyEncoding = Encoding.UTF8;
                mensaje.SubjectEncoding = Encoding.UTF8;

                /*
                 * Convierte el contenido XML en un flujo de memoria.
                 * El flujo será liberado automáticamente cuando se cierre
                 * el mensaje y se eliminen sus archivos adjuntos.
                 */
                if (!string.IsNullOrWhiteSpace(xmlContent))
                {
                    byte[] bytesXml =
                        Encoding.UTF8.GetBytes(xmlContent);

                    MemoryStream memoriaXml =
                        new MemoryStream(bytesXml);

                    Attachment adjuntoXml = new Attachment(
                        memoriaXml,
                        "Factura_" + idFactura + ".xml",
                        "application/xml");

                    mensaje.Attachments.Add(adjuntoXml);
                }

                /*
                 * Adjunta el PDF solamente cuando se recibió una ruta válida
                 * y el archivo existe físicamente.
                 */
                if (!string.IsNullOrWhiteSpace(rutaPdf) &&
                    File.Exists(rutaPdf))
                {
                    Attachment adjuntoPdf = new Attachment(
                        rutaPdf,
                        "application/pdf");

                    mensaje.Attachments.Add(adjuntoPdf);
                }

                /*
                 * Configura el cliente SMTP con conexión segura y las
                 * credenciales almacenadas en App.config.
                 */
                using (SmtpClient smtp = new SmtpClient(
                    SMTP_HOST,
                    SMTP_PUERTO))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(
                        usuario,
                        password);

                    smtp.Send(mensaje);
                }
            }
        }

        /// <summary>
        /// Construye el contenido HTML estándar del correo utilizado para
        /// notificar la emisión de una factura.
        /// </summary>
        /// <param name="codigoPropiedad">
        /// Código de la propiedad a la que pertenece la factura.
        /// </param>
        /// <param name="idFactura">
        /// Identificador o número de la factura emitida.
        /// </param>
        /// <param name="fecha">
        /// Fecha de emisión que se mostrará en el correo.
        /// </param>
        /// <param name="totalColones">
        /// Total de la factura expresado en colones y previamente formateado.
        /// </param>
        /// <param name="totalDolares">
        /// Total de la factura expresado en dólares y previamente formateado.
        /// </param>
        /// <returns>
        /// Cadena con la estructura HTML completa del mensaje.
        /// </returns>
        /// <remarks>
        /// El cuerpo generado incluye una tabla con el número de factura,
        /// fecha, total en colones y total en dólares. También informa que
        /// el mensaje contiene los archivos PDF y XML correspondientes.
        /// </remarks>
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

  <p>
    Estimado residente de la propiedad
    <strong>{codigoPropiedad}</strong>,
  </p>

  <p>
    Se ha emitido una nueva factura con los siguientes datos:
  </p>

  <table
    border='1'
    cellpadding='6'
    cellspacing='0'
    style='border-collapse:collapse;'>

    <tr>
      <td><strong>N.° Factura</strong></td>
      <td>{idFactura}</td>
    </tr>

    <tr>
      <td><strong>Fecha</strong></td>
      <td>{fecha}</td>
    </tr>

    <tr>
      <td><strong>Total (₡)</strong></td>
      <td>{totalColones}</td>
    </tr>

    <tr>
      <td><strong>Total ($)</strong></td>
      <td>{totalDolares}</td>
    </tr>
  </table>

  <p>
    Los archivos adjuntos incluyen la factura en formato
    <strong>PDF</strong> y <strong>XML</strong>.
  </p>

  <p>
    Atentamente,<br/>
    Administración del Condominio
  </p>
</body>
</html>";
        }
    }
}