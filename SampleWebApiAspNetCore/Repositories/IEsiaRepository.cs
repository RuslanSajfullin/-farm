using System.Collections.Generic;
using System.Linq;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.Repositories
{
    public interface IEsiaRepository
    {
        EsiaItem GetSingle(int id);
        void Add(EsiaItem item);
        void Delete(int id);
        EsiaItem Update(int id, EsiaItem item);
        IQueryable<EsiaItem> GetAll(QueryParameters queryParameters);

        ICollection<EsiaItem> GetRandomMeal();
        int Count();

        bool Save();
    }
}
