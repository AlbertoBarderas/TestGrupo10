using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.BoeReading
{
    public interface IBoeReadingServices
    {
        List<BOEReading> GetListOfReadings();
        List<BOEReading> GetListOfReadings(int month);

        bool SaveListBoeReading(List<BOEReading> bOEReadings);
        bool ExistsBoeRead(List<BOEReading> boeReadings, DateTime readDate);
        bool AddBoeReading(BOEReading boeReading, ref List<BOEReading> actualBoeReadings);
    }
}
