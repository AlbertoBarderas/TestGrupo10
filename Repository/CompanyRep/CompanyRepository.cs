using Entities.DTOS;
using Repository.DocumentDBRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CompanyRep
{
    public class CompanyRepository : DocumentDBRepository<Company>,ICompanyRepository
    {

    }
}
