using System.Threading.Tasks;
using System;
using Core.Entities;

namespace Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity:BaseEntity;
        Task<int> Complete();
    }
}