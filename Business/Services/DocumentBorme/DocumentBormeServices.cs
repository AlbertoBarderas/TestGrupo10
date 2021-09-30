using Business.Services.BoeReading;
using Business.Services.CompanyServ;
using Business.Utils;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DocumentBorme
{
    public class DocumentBormeServices : IDocumentBormeServices
    {
        private readonly IBoeReadingServices _boeReadingServices;

        private readonly ICompanyServices _companyServices;

        public DocumentBormeServices(IBoeReadingServices boeReadingServices, ICompanyServices companyServices)
        {
            _boeReadingServices = boeReadingServices;
            _companyServices = companyServices;
        }

        #region public
        /// <summary>
        /// Lee los documentos del BOE por una fecha dada
        /// </summary>
        /// <param name="readDate"></param>
        /// <returns></returns>
        public bool ReadDocumentsByDate(DateTime readDate)
        {
            try
            {
                //Aquí haríamos un bucle con un algoritmo que recorriese todas las provincias y generase un nombre de fichero a descargar por fecha (que llega como parámetro) y provincia.
                //Para el ejemplo usaremos los 2 pdfs que sabemos que funcionan
                const string _urlAlbacete = @"https://www.boe.es/borme/dias/2021/03/05/pdfs/BORME-A-2021-44-02.pdf";
                const string _urlAlicante = @"https://www.boe.es/borme/dias/2021/03/05/pdfs/BORME-A-2021-44-03.pdf";

                //Descargamos los pdfs en la carpeta con la fecha
                string pathToSave = @"C:\TestGrupo10Files\" + readDate.ToString("MMddyyyy");
                DownloadAndConvertDocument("ALBACETE", readDate, _urlAlbacete, pathToSave);
                DownloadAndConvertDocument("ALICANTE", readDate, _urlAlicante, pathToSave);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        #endregion

        #region private
        private bool DownloadAndConvertDocument(string provinceName, DateTime readDate, string urlFile, string pathToSave)
        {

            string fileName = provinceName + ".pdf";
            string filePath = pathToSave + @"\" + fileName;
            //Primero descargamos el documento
            if (HelperFiles.DownloadFileToSpecificPath(urlFile, pathToSave, fileName))
            {

                //Convertimos el pdf en txt para leerlo y tratarlo.
                if (HelperFiles.pdfToTxt(filePath, pathToSave, "temporal_" + provinceName + ".txt") == true)
                {
                    ReadAndWorkTxtFile(pathToSave + @"\temporal_" + provinceName + ".txt");

                    //Grabamos la lectura en la fecha indicada
                    SaveBoeReading(readDate);
                }
                else
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }


        }

        private bool SaveBoeReading(DateTime readDate)
        {

            List<BOEReading> actualBoeReadings = _boeReadingServices.GetListOfReadings();
            BOEReading boeReading = new BOEReading { ReadDate = readDate };
            // boeReadingServices.AddBoeReading(boeReading, ref actualBoeReadings);
            _boeReadingServices.AddBoeReading(boeReading, ref actualBoeReadings);
            return _boeReadingServices.SaveListBoeReading(actualBoeReadings);

        }

        private bool ReadAndWorkTxtFile(string filePath)
        {
            string line;
            string provinceName = string.Empty;
            int counter = 0;
            List<Company> actualCompanyList = GetListOfCompanies();

            using (var streamReader = new System.IO.StreamReader(filePath))
            {
                while ((line = streamReader.ReadLine()) != null)
                {

                    if (counter == 5)
                    {
                        //Aquí tenemos el nombre de la provincia
                        provinceName = line.Trim();
                    }

                    //No me voy a complicar mucho y trataré las líneas que llegan con un "-" en la posición 7 como las cabeceras de las empresas.
                    if (line.IndexOf("-") == 7)
                    {

                        AddCompany(line, provinceName, ref actualCompanyList);
                    }

                    counter++;
                }

                streamReader.Close();
            }


            if (File.Exists(filePath))
                File.Delete(filePath);
            //Grabamos en Bd la lista de compañías
            SaveListCompany(actualCompanyList);

            return true;
        }

        private bool AddCompany(string line, string provinceName, ref List<Company> actualCompanyList)
        {
            return _companyServices.AddCompany(line, provinceName, ref actualCompanyList);

        }

        private List<Company> GetListOfCompanies()
        {

            return _companyServices.GetListOfCompanies();
        }
        private bool SaveListCompany(List<Company> companies)
        {

            return _companyServices.SaveListCompany(companies);
        }

        #endregion



    }
}
