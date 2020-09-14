using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IProductRepository
    {
         Task<Product> GetProduct(int id);

         Task<IReadOnlyList<Product>> GetProducts();
    }
}