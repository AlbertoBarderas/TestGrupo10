using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities.DTOS;
using System.Linq.Expressions;
using Business.Utils;
using Repository.CompanyRep;

namespace Business.Services.CompanyServ
{
    public class CompanyServices : ICompanyServices
    {
        const string _pathFile = @"C:\TestGrupo10Files\Data\Company.json";
        const string _pathDirectory = @"C:\TestGrupo10Files\Data";

        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }

        /// <summary>
        /// Devuelve una lista de empresas 
        /// </summary>
        /// <param name="provinceName"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public List<Company> GetListOfCompanies(string provinceName = "", string companyName = "")
        {
            try
            {
                //TODO para los filtros sería conveniente usar otro método tipo Odata o una lista de filtros que se construyese dinámicamente

                Func<Company, bool> filter = p => 1 == 1;

                if (provinceName != string.Empty)
                {
                    Func<Company, bool> filterProvince = p => p.ProvinceName.ToLower().Contains(provinceName.ToLower());
                    filter = filter + filterProvince;
                }
                if (companyName != string.Empty)
                {
                    Func<Company, bool> filterCompany = p => p.CompanyName.ToLower().Contains(companyName.ToLower());
                    filter = filter + filterCompany;
                }

                return _companyRepository.GetObjectFromJSONFile(_pathFile, filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Devuelve una lista de empresas 
        /// </summary>
        /// <returns></returns>
        public List<Company> GetListOfCompanies()
        {
            try
            {
                return _companyRepository.GetObjectFromJSONFile(_pathFile);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Graba una lista de empresas en el repositorio
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public bool SaveListCompany(List<Company> companies)
        {
            try
            {
                HelperFiles.CreateDirectoryIfNotExists(_pathDirectory);
                return _companyRepository.SaveJsonDocument(companies, _pathFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Devuelve si existe o no una empresa en la lista pasada filtrando por id
        /// </summary>
        /// <param name="companies"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsCompany(List<Company> companies, int id)
        {
            //Primero comprobamos si la entidad ya existe en el JSON. Si usasemos una base de datos no Sql como COSMOSDB no tendríamos que hacer estas cosas y si es Sql Server tampoco
            //Pero al tener ficheros tenemos que traernos el fichero, comprobar si existe o no
            try
            {
                return companies.Exists(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Agrega una empresa a la lista pasada si no existe, en caso de existir actualiza los datos.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="provinceName"></param>
        /// <param name="actualCompanyList"></param>
        /// <returns></returns>
        public bool AddCompany(string line, string provinceName, ref List<Company> actualCompanyList)
        {

            try
            {
                int id = Convert.ToInt32(line.ToString().Split('-')[0].Trim());
                string companyName = line.ToString().Split('-')[1].Trim();
                if (!ExistsCompany(actualCompanyList, id))
                {
                    Company company = new Company() { ProvinceName = provinceName, CreationDate = DateTime.Now, Id = id, CompanyName = companyName };
                    actualCompanyList.Add(company);
                }
                else
                {
                    //Si existe actualizariamos el dato de companyName o los datos que necesitemos actualizar
                    Company company = actualCompanyList.Where(p => p.Id == id).FirstOrDefault();
                    company.CompanyName = companyName;
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
