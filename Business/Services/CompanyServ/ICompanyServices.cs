using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CompanyServ
{
    public interface ICompanyServices
    {
        List<Company> GetListOfCompanies(string provinceName = "", string companyName = "");

        List<Company> GetListOfCompanies();

        bool SaveListCompany(List<Company> companies);

        bool ExistsCompany(List<Company> companies, int id);

        bool AddCompany(string line, string provinceName, ref List<Company> actualCompanyList);

    }
}
