using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SkinetContext _context;
        public GenericRepository(SkinetContext context)
        {
            _context = context;
        }

        public async Task<int> GetCountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetEntityListWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec, int id)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetEntityListWithOutSpec()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithOutSpec(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}