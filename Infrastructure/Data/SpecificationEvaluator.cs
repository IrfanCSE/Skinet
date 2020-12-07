using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null){
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null){
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDesc != null){
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            // look up on every include then add one by one sequentialy.
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            if(spec.IsPagingEnable){
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
        }
    }
}