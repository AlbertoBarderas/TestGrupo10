using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DocumentDBRep
{
    public class DocumentDBRepository<T> : IDocumentDBRepository<T> where T : new()
    {
        public bool SaveJsonDocument(T entity, string filePath)
        {

            return true;
        }

        /// <summary>
        /// Salva una lista de entidades a un fichero JSON que usamos de repositorio
        /// </summary>
        /// <param name="entityList"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool SaveJsonDocument(List<T> entityList, string filePath)
        {
            try
            {
                string strEntityList = JsonConvert.SerializeObject(entityList.ToArray(), Formatting.Indented);
                File.WriteAllText(filePath, strEntityList);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene una lista de entidades a un fichero JSON que usamos de repositorio
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> GetObjectFromJSONFile(string filePath, Func<T, bool> filter)
        {
            try
            {
                List<T> lista = new List<T>();
                lista = GetObjectFromJSONFile(filePath);
                return lista.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene una lista de entidades a un fichero JSON que usamos de repositorio
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<T> GetObjectFromJSONFile(string filePath)
        {
            try
            {
                string strListObjectFromJsonFile = string.Empty;

                if (!File.Exists(filePath))
                    return new List<T>();

                using (var reader = new StreamReader(filePath))
                {
                    strListObjectFromJsonFile = reader.ReadToEnd();
                }

                if (strListObjectFromJsonFile == string.Empty)
                {
                    return new List<T>();
                }

                List<T> jsonList = (List<T>)JsonConvert.DeserializeObject<List<T>>(strListObjectFromJsonFile);
                return jsonList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         

        }


    }
}
