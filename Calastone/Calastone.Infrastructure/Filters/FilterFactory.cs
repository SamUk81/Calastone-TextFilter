using Calastone.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calastone.Infrastructure.Filters
{
    public class FilterFactory : IFilterFactory
    {
        private IEnumerable<IFilter> filters => GetFilters();

        public IFilter Create(string filterName)
        {
            return filters.SingleOrDefault(s => s.WhichFilterToHandle(filterName));
        }

        private IEnumerable<IFilter> GetFilters()
        {
            var filterTypes = System.Reflection.Assembly.GetExecutingAssembly().ExportedTypes
                             .Where(t => t.GetInterfaces().Contains(typeof(IFilter)));

            var filters = new List<IFilter>();

            foreach (var type in filterTypes)
            {
                filters.Add(type.GetConstructor(Type.EmptyTypes)?.Invoke(new object[0]) as IFilter);
            }

            return filters;
        }
    }
}
