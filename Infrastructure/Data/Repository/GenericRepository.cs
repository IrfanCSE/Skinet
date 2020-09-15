using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly SkinetContext _context;
        public GenericRepository (SkinetContext context) {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetEntityListWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListItem () {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetSingleItem (int id) {
            return await _context.Set<T>().FindAsync(id);
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }
    }
}