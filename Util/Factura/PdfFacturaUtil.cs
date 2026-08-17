using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Util.Factura
{
    /// <summary>
    /// Proporciona operaciones para generar y guardar facturas en formato PDF.
    /// </summary>
    /// <remarks>
    /// Esta clase construye un documento PDF básico a partir de una
    /// <see cref="FacturaDTO"/> sin utilizar bibliotecas externas.
    ///
    /// El archivo generado incluye la información general de la factura,
    /// sus cargos, los montos en colones y dólares, el tipo de cambio y
    /// el saldo pendiente.
    /// </remarks>
    public static class PdfFacturaUtil
    {
        /// <summary>
        /// Configuración cultural utilizada para mostrar cantidades monetarias
        /// según el formato de Costa Rica.
        /// </summary>
        private static readonly CultureInfo CulturaCostaRica =
            CultureInfo.GetCultureInfo("es-CR");

        /// <summary>
        /// Genera un documento PDF con la información de una factura y lo
        /// guarda en la carpeta indicada.
        /// </summary>
        /// <param name="factura">
        /// Factura que contiene los datos generales, montos y detalles
        /// que se incluirán en el documento.
        /// </param>
        /// <param name="carpetaDestino">
        /// Carpeta en la que se guardará el PDF. Si no se proporciona una
        /// carpeta, el documento se guardará en la carpeta
        /// <c>Documentos\Facturas</c> del usuario.
        /// </param>
        /// <returns>
        /// Ruta completa del archivo PDF generado.
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
            if (factura == null)
            {
                throw new ArgumentNullException("factura");
            }

            // Si no se recibe una carpeta, se utiliza Documentos\Facturas.
            if (string.IsNullOrWhiteSpace(carpetaDestino))
            {
                carpetaDestino = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "Facturas");
            }

            // Garantiza que la carpeta de destino exista antes de crear el PDF.
            Directory.CreateDirectory(carpetaDestino);

            // Se genera un nombre único utilizando el número y fecha
            // de la factura.
            string nombreArchivo =
                "Factura_" +
                factura.IdFactura +
                "_" +
                factura.Fecha.ToString("yyyyMMdd") +
                ".pdf";

            string ruta = Path.Combine(
                carpetaDestino,
                nombreArchivo);

            // Convierte la información de la factura en líneas imprimibles.
            List<string> lineas = ConstruirLineas(factura);

            // Escribe la estructura y el contenido del documento PDF.
            EscribirPdf(ruta, lineas);

            return ruta;
        }

        /// <summary>
        /// Construye las líneas de texto que aparecerán dentro del documento PDF.
        /// </summary>
        /// <param name="factura">
        /// Factura de la cual se obtendrá la información que se mostrará.
        /// </param>
        /// <returns>
        /// Lista ordenada de líneas con los datos generales, detalles y
        /// totales de la factura.
        /// </returns>
        /// <remarks>
        /// Cada detalle muestra la descripción y el tipo de cargo, además
        /// del monto base, el impuesto y el subtotal correspondiente.
        /// </remarks>
        private static List<string> ConstruirLineas(
            FacturaDTO factura)
        {
            List<string> lineas = new List<string>();

            // Encabezado e información general de la factura.
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

            // Agrega los cargos asociados a la factura.
            if (factura.Detalles != null &&
                factura.Detalles.Count > 0)
            {
                foreach (DetalleFacturaDTO detalle in factura.Detalles)
                {
                    // Evita errores si la colección contiene un elemento nulo.
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
                        " (" +
                        (detalle.TipoCargo ?? "Cargo") +
                        ")");

                    lineas.Add(
                        "  Base CRC " +
                        detalle.MontoBase.ToString(
                            "N2",
                            CulturaCostaRica) +
                        " | IVA CRC " +
                        detalle.IVA.ToString(
                            "N2",
                            CulturaCostaRica) +
                        " | Total CRC " +
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

            // Totales y datos monetarios de la factura.
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

        /// <summary>
        /// Escribe físicamente el documento PDF en la ruta especificada.
        /// </summary>
        /// <param name="ruta">
        /// Ruta completa en la que se creará el archivo PDF.
        /// </param>
        /// <param name="lineas">
        /// Líneas de texto que se incluirán en el documento.
        /// </param>
        /// <remarks>
        /// El método crea manualmente una estructura PDF básica compuesta por
        /// un catálogo, una colección de páginas, una página, un flujo de
        /// contenido y una fuente Helvetica.
        ///
        /// El documento generado utiliza una página con tamaño aproximado A4.
        /// </remarks>
        /// <exception cref="IOException">
        /// Se produce cuando el archivo no puede crearse o escribirse.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Se produce cuando no existen permisos de escritura sobre la ruta.
        /// </exception>
        private static void EscribirPdf(
            string ruta,
            List<string> lineas)
        {
            StringBuilder contenido =
                new StringBuilder();

            // Inicia el bloque de texto del PDF.
            contenido.Append("BT\n");

            // Configura la fuente Helvetica con tamaño 11.
            contenido.Append("/F1 11 Tf\n");

            // Establece la posición inicial del texto.
            contenido.Append("50 790 Td\n");

            for (int i = 0; i < lineas.Count; i++)
            {
                // Desplaza la posición vertical para escribir la siguiente línea.
                if (i > 0)
                {
                    contenido.Append("0 -22 Td\n");
                }

                contenido
                    .Append("(")
                    .Append(Escapar(lineas[i]))
                    .Append(") Tj\n");
            }

            // Finaliza el bloque de texto.
            contenido.Append("ET");

            byte[] stream =
                Encoding.ASCII.GetBytes(contenido.ToString());

            /*
             * Objetos internos del documento:
             * 1. Catálogo principal.
             * 2. Colección de páginas.
             * 3. Página del documento.
             * 4. Flujo con el contenido.
             * 5. Fuente utilizada.
             */
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

                // Encabezado que identifica la versión del formato PDF.
                escritor.Write("%PDF-1.4\n");
                escritor.Flush();

                // Guarda la posición de cada objeto para construir
                // posteriormente la tabla de referencias cruzadas.
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

                // Posición en la que comienza la tabla de referencias.
                long posicionXref = archivo.Position;

                escritor.Write(
                    "xref\n0 " +
                    (objetos.Count + 1) +
                    "\n");

                // Primera entrada reservada por el estándar PDF.
                escritor.Write(
                    "0000000000 65535 f \n");

                // Escribe la posición exacta de cada objeto del documento.
                for (int i = 1; i < posiciones.Count; i++)
                {
                    escritor.Write(
                        posiciones[i].ToString("0000000000") +
                        " 00000 n \n");
                }

                // Escribe el tráiler, la referencia al catálogo principal
                // y la posición inicial de la tabla de referencias.
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

        /// <summary>
        /// Prepara una cadena de texto para que pueda escribirse de forma
        /// segura dentro del contenido del documento PDF.
        /// </summary>
        /// <param name="texto">
        /// Texto original que se desea incluir en el documento.
        /// </param>
        /// <returns>
        /// Texto sin marcas diacríticas y con los caracteres especiales
        /// del formato PDF correctamente escapados.
        /// </returns>
        /// <remarks>
        /// Debido a que el documento utiliza codificación ASCII y una fuente
        /// básica, se eliminan las marcas diacríticas de caracteres como
        /// vocales acentuadas.
        ///
        /// También se escapan las barras invertidas y los paréntesis porque
        /// tienen un significado especial dentro de una cadena PDF.
        /// </remarks>
        private static string Escapar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return string.Empty;
            }

            // Separa las letras de sus marcas diacríticas.
            string normalizado =
                texto.Normalize(NormalizationForm.FormD);

            StringBuilder resultado =
                new StringBuilder();

            foreach (char caracter in normalizado)
            {
                UnicodeCategory categoria =
                    CharUnicodeInfo.GetUnicodeCategory(caracter);

                // Omite las marcas diacríticas porque el PDF utiliza ASCII.
                if (categoria != UnicodeCategory.NonSpacingMark)
                {
                    resultado.Append(caracter);
                }
            }

            // Escapa los caracteres reservados dentro de una cadena PDF.
            return resultado
                .ToString()
                .Normalize(NormalizationForm.FormC)
                .Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }
    }
}