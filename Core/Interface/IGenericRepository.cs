using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task<T> GetSingleItem(int id);
         Task<IReadOnlyList<T>> GetListItem();
         Task<T> GetEntityWithSpec(ISpecifications<T> spec);
         Task<IReadOnlyList<T>> GetEntityListWithSpec(ISpecifications<T> spec);
         Task<int> GetCountAsync(ISpecifications<T> spec);
    }
}