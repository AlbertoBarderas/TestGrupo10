using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public static class HelperFiles
    {

        /// <summary>
        /// Método que descarga un archivo de Internet en la ruta indicada.
        /// </summary>
        /// <param name="strURLFile">URL del archivo que se desea descargar</param>
        /// <param name="strPathToSave">Ruta donde se desea almacenar el archivo</param>
        public static bool DownloadFileToSpecificPath(string strURLFile, string pathToSave, string fileName)
        {
            // Se encierra el código dentro de un bloque try-catch.
            string filepath = pathToSave + @"\" + fileName;
            try
            {
                // Se valida que la URL no esté en blanco.
                if (String.IsNullOrEmpty(strURLFile))
                {
                    // Se retorna un mensaje de error al usuario.
                    throw new ArgumentNullException("La dirección URL del documento es nula o se encuentra en blanco.");
                }// Fin del if que valida que la URL no esté en blanco.

                // Se valida que la ruta física no esté en blanco.
                if (String.IsNullOrEmpty(pathToSave))
                {
                    // Se retorna un mensaje de error al usuario.
                    throw new ArgumentNullException("La ruta para almacenar el documento es nula o se encuentra en blanco.");
                }// Fin del if que valida que la ruta física no esté en blanco.


                //Si no existe el directorio lo creamos
                CreateDirectoryIfNotExists(pathToSave);
           

                // Se descargar el archivo indicado en la ruta específicada.
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.DownloadFile(strURLFile, filepath);
                }
                return true;
            }
            catch (Exception ex)
            {
                //Grabaríamos porque no se ha traido el fichero, puede que no exista para eso día o simila
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Crea un directorio si no existe
        /// </summary>
        /// <param name="pathDirectory"></param>
        public static void CreateDirectoryIfNotExists(string pathDirectory)
        {
            try
            {
                if (!Directory.Exists(pathDirectory))
                {
                    //Si no existe el directorio lo creamos
                    Directory.CreateDirectory(pathDirectory);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        /// <summary>
        /// Convierte pdf en txt
        /// </summary>
        /// <param name="filepathPdf"></param>
        /// <param name="pathToSave"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool pdfToTxt(string filepathPdf, string pathToSave, string fileName)
        {
            try
            {
                string filepath = pathToSave + @"\" + fileName;
                //Si no existe el directorio lo creamos
                CreateDirectoryIfNotExists(pathToSave);

                PdfDocument pdfDocument = new PdfDocument(new PdfReader(filepathPdf));

                using (StreamWriter streamWriter = new StreamWriter(filepath))
                {
                    for (int i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
                    {
                        var page = pdfDocument.GetPage(i);
                        string textPage = PdfTextExtractor.GetTextFromPage(page);
                        streamWriter.Write(textPage);
                    }
                    streamWriter.Close();
                }
                pdfDocument.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

    }
}
