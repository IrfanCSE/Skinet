using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository {
        private readonly SkinetContext _context;
        public ProductRepository (SkinetContext context) {
            _context = context;
        }

        public async Task<Product> GetProduct (int id) {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProducts () {
            return await _context.Products.ToListAsync();
        }
    }
}