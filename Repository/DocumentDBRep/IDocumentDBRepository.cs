using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DocumentDBRep
{
    public interface IDocumentDBRepository<T> where T : new()
    {
        bool SaveJsonDocument(T entity, string filePath);
        bool SaveJsonDocument(List<T> entityList, string filePath);
        List<T> GetObjectFromJSONFile(string filePath, Func<T, bool> filter);
        List<T> GetObjectFromJSONFile(string filePath);

    }
}
