using DTO;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Util.Factura
{
    /// <summary>
    /// Proporciona operaciones para generar y guardar facturas en formato XML.
    /// </summary>
    /// <remarks>
    /// La clase transforma un objeto <see cref="FacturaDTO"/> en un documento
    /// XML que contiene el encabezado, los totales y los cargos incluidos en
    /// la factura.
    ///
    /// El XML generado puede almacenarse en la base de datos, guardarse como
    /// archivo físico o enviarse como adjunto por correo electrónico.
    /// </remarks>
    public static class XmlFacturaUtil
    {
        /// <summary>
        /// Genera el documento XML completo de una factura.
        /// </summary>
        /// <param name="factura">
        /// Factura que contiene la información general, los montos y los
        /// detalles que se incluirán en el documento XML.
        /// </param>
        /// <returns>
        /// Cadena que contiene el documento XML completo de la factura.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando el parámetro <paramref name="factura"/> es nulo.
        /// </exception>
        /// <remarks>
        /// El documento se divide en dos secciones principales:
        /// <c>Encabezado</c> y <c>Detalle</c>.
        ///
        /// Los valores decimales se generan utilizando
        /// <see cref="CultureInfo.InvariantCulture"/> para que el separador
        /// decimal siempre sea un punto, independientemente de la
        /// configuración regional del equipo.
        /// </remarks>
        public static string GenerarXml(FacturaDTO factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(
                    "factura",
                    "La factura no puede ser nula.");
            }

            XDocument documento = new XDocument(
                new XElement(
                    "Factura",

                    /*
                     * Encabezado del documento.
                     * Contiene la información general y financiera
                     * de la factura.
                     */
                    new XElement(
                        "Encabezado",

                        new XElement(
                            "IdFactura",
                            factura.IdFactura),

                        new XElement(
                            "Fecha",
                            factura.Fecha.ToString(
                                "yyyy-MM-ddTHH:mm:ss")),

                        new XElement(
                            "CodigoPropiedad",
                            factura.CodigoPropiedad ??
                            string.Empty),

                        new XElement(
                            "IdPropiedad",
                            factura.IdPropiedad),

                        new XElement(
                            "TotalColones",
                            factura.TotalColones.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "TotalDolares",
                            factura.TotalDolares.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "TipoCambio",
                            factura.TipoCambio.ToString(
                                "F4",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "TotalPagado",
                            factura.TotalPagado.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "SaldoPendiente",
                            factura.SaldoPendiente.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "Estado",
                            factura.Estado ?? "Emitida")
                    ),

                    /*
                     * Genera la sección que contiene cada uno de los
                     * cargos incluidos en la factura.
                     */
                    GenerarNodoDetalle(factura)
                )
            );

            /*
             * SQL Server recibe el documento como una cadena Unicode.
             * Por ese motivo no se agrega una declaración encoding="UTF-8",
             * ya que dicha declaración corresponde principalmente cuando
             * el documento se escribe directamente como una secuencia
             * de bytes.
             */
            return documento.ToString();
        }

        /// <summary>
        /// Genera el XML de una factura y lo guarda como un archivo físico.
        /// </summary>
        /// <param name="factura">
        /// Factura que se utilizará para generar el contenido del archivo.
        /// </param>
        /// <param name="carpetaDestino">
        /// Carpeta donde se guardará el documento XML. Si el valor es nulo
        /// o está vacío, se utilizará la carpeta
        /// <c>Documentos\Facturas</c> del usuario.
        /// </param>
        /// <returns>
        /// Ruta completa del archivo XML generado.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando el parámetro <paramref name="factura"/> es nulo.
        /// </exception>
        /// <exception cref="IOException">
        /// Se produce cuando ocurre un error al crear la carpeta o escribir
        /// el archivo.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Se produce cuando el usuario no tiene permisos para escribir en
        /// la carpeta seleccionada.
        /// </exception>
        public static string GuardarEnArchivo(
            FacturaDTO factura,
            string carpetaDestino = null)
        {
            /*
             * GenerarXml también valida que la factura no sea nula antes
             * de intentar utilizar sus propiedades.
             */
            string xml = GenerarXml(factura);

            /*
             * Si no se indicó una ubicación, se guarda dentro de la carpeta
             * Facturas de Documentos.
             */
            if (string.IsNullOrWhiteSpace(carpetaDestino))
            {
                carpetaDestino = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "Facturas");
            }

            // Crea la carpeta únicamente cuando todavía no existe.
            Directory.CreateDirectory(carpetaDestino);

            /*
             * El identificador y la fecha permiten distinguir fácilmente
             * cada documento generado.
             */
            string nombreArchivo =
                "Factura_" +
                factura.IdFactura +
                "_" +
                factura.Fecha.ToString("yyyyMMdd") +
                ".xml";

            string rutaCompleta = Path.Combine(
                carpetaDestino,
                nombreArchivo);

            // Guarda el documento utilizando codificación UTF-8.
            File.WriteAllText(
                rutaCompleta,
                xml,
                Encoding.UTF8);

            return rutaCompleta;
        }

        /// <summary>
        /// Genera el nodo XML que contiene todas las líneas de detalle
        /// de una factura.
        /// </summary>
        /// <param name="factura">
        /// Factura que contiene la colección de cargos facturados.
        /// </param>
        /// <returns>
        /// Elemento XML llamado <c>Detalle</c> con una línea por cada cargo.
        /// Si la factura no posee cargos, retorna el elemento vacío.
        /// </returns>
        /// <remarks>
        /// Cada línea incluye el identificador del cargo, descripción, tipo,
        /// monto base, impuesto, cantidad, precio unitario y subtotal.
        /// </remarks>
        private static XElement GenerarNodoDetalle(
            FacturaDTO factura)
        {
            XElement detalle = new XElement("Detalle");

            if (factura.Detalles != null)
            {
                foreach (DetalleFacturaDTO detalleFactura
                    in factura.Detalles)
                {
                    /*
                     * Evita que un elemento nulo dentro de la colección
                     * interrumpa la generación completa del documento.
                     */
                    if (detalleFactura == null)
                    {
                        continue;
                    }

                    XElement linea = new XElement(
                        "Linea",

                        new XElement(
                            "IdCargo",
                            detalleFactura.IdCargo),

                        new XElement(
                            "Descripcion",
                            detalleFactura.DescripcionCargo ??
                            string.Empty),

                        new XElement(
                            "Tipo",
                            detalleFactura.TipoCargo ??
                            string.Empty),

                        new XElement(
                            "MontoBase",
                            detalleFactura.MontoBase.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "IVA",
                            detalleFactura.IVA.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "Cantidad",
                            detalleFactura.Cantidad),

                        new XElement(
                            "PrecioUnitario",
                            detalleFactura.Precio.ToString(
                                "F2",
                                CultureInfo.InvariantCulture)),

                        new XElement(
                            "SubTotal",
                            detalleFactura.SubTotal.ToString(
                                "F2",
                                CultureInfo.InvariantCulture))
                    );

                    detalle.Add(linea);
                }
            }

            return detalle;
        }
    }
}