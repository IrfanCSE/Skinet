using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SkinetContext _context;
        private Hashtable _repository;
        public UnitOfWork(SkinetContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repository == null) _repository = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repository.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repository.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repository[type];
        }
    }
}