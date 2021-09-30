using Entities.DTOS;
using Repository.DocumentDBRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BoeReadRep
{
   public interface IBoeReadingRepository: IDocumentDBRepository<BOEReading>
    {

    }
}
