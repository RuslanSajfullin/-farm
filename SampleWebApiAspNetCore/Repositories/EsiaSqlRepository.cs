using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SampleWebApiAspNetCore.Repositories
{
    public class EsiaSqlRepository : IEsiaRepository
    {
        private readonly EsiaDbContext _EsiaDbContext;

        public EsiaSqlRepository(EsiaDbContext EsiaDbContext)
        {
            _EsiaDbContext = EsiaDbContext;
        }

        public EsiaItem GetSingle(int id)
        {
            return _EsiaDbContext.EsiaItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(EsiaItem item)
        {
            _EsiaDbContext.EsiaItems.Add(item);
        }

        public void Delete(int id)
        {
            EsiaItem EsiaItem = GetSingle(id);
            _EsiaDbContext.EsiaItems.Remove(EsiaItem);
        }

        public EsiaItem Update(int id, EsiaItem item)
        {
            _EsiaDbContext.EsiaItems.Update(item);
            return item;
        }

        public IQueryable<EsiaItem> GetAll(QueryParameters queryParameters)
        {
            IQueryable<EsiaItem> _allItems = _EsiaDbContext.EsiaItems.OrderBy(queryParameters.OrderBy,
              queryParameters.IsDescending());

            if (queryParameters.HasQuery())
            {
                _allItems = _allItems
                    .Where(x => x.Calories.ToString().Contains(queryParameters.Query.ToLowerInvariant())
                    || x.Name.ToLowerInvariant().Contains(queryParameters.Query.ToLowerInvariant()));
            }

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public int Count()
        {
            return _EsiaDbContext.EsiaItems.Count();
        }

        public bool Save()
        {
            return (_EsiaDbContext.SaveChanges() >= 0);
        }

        public ICollection<EsiaItem> GetRandomMeal()
        {
            List<EsiaItem> toReturn = new List<EsiaItem>();

            toReturn.Add(GetRandomItem("Starter"));
            toReturn.Add(GetRandomItem("Main"));
            toReturn.Add(GetRandomItem("Dessert"));

            return toReturn;
        }

        private EsiaItem GetRandomItem(string type)
        {
            return _EsiaDbContext.EsiaItems
                .Where(x => x.Type == type)
                .OrderBy(o => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}
