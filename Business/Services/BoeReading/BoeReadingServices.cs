using Business.Utils;
using Entities.DTOS;
using Repository;
using Repository.BoeReadRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.BoeReading
{
    public class BoeReadingServices: IBoeReadingServices
    {
        const string _pathFile = @"C:\TestGrupo10Files\Data\BoeReading.json";
        const string _pathDirectory = @"C:\TestGrupo10Files\Data";

        private readonly IBoeReadingRepository _boeReadingRepository;

        public BoeReadingServices(IBoeReadingRepository boeReadingRepository)
        {
            _boeReadingRepository = boeReadingRepository;
           
        }

        /// <summary>
        /// Devuelve una lista de lecturas realizadas en el BOE
        /// </summary>
        /// <returns></returns>
        public List<BOEReading> GetListOfReadings()
        {
            try
            {
                return _boeReadingRepository.GetObjectFromJSONFile(_pathFile).OrderBy(p=>p.ReadDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        /// <summary>
        /// Devuelve una lista de lecturas realizadas en el BOE
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<BOEReading> GetListOfReadings(int month)
        {
            try
            {
                Func<BOEReading, bool> filter = p => p.ReadDate.Month == month;
                return _boeReadingRepository.GetObjectFromJSONFile(_pathFile, filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }


        /// <summary>
        /// Llama al repositorio para grabar una lista de lecturas
        /// </summary>
        /// <param name="boeReadings"></param>
        /// <returns></returns>
        public bool SaveListBoeReading(List<BOEReading> boeReadings)
        {
            try
            {
                HelperFiles.CreateDirectoryIfNotExists(_pathDirectory);
                return _boeReadingRepository.SaveJsonDocument(boeReadings, _pathFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        /// <summary>
        /// Devuelve si existe o no una lectura al boe por fecha.
        /// </summary>
        /// <param name="boeReadings"></param>
        /// <param name="readDate"></param>
        /// <returns></returns>
        public bool ExistsBoeRead(List<BOEReading> boeReadings, DateTime readDate)
        {
            //Primero comprobamos si la entidad ya existe en el JSON. Si usasemos una base de datos no Sql como COSMOSDB no tendríamos que hacer estas cosas y si es Sql Server tampoco
            //Pero al tener ficheros tenemos que traernos el fichero, comprobar si existe o no
            try
            {
                return boeReadings.Exists(p => p.ReadDate.Date == readDate.Date);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        /// <summary>
        /// Agrega un objeto BOEReading a la lista en caso de no existir.
        /// </summary>
        /// <param name="boeReading"></param>
        /// <param name="actualBoeReadings"></param>
        /// <returns></returns>
        public bool AddBoeReading(BOEReading boeReading, ref List<BOEReading> actualBoeReadings)
        {
            try
            {
                if (!ExistsBoeRead(actualBoeReadings, boeReading.ReadDate))
                {
                    actualBoeReadings.Add(boeReading);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         

        }

    }
}
