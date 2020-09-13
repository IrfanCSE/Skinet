using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SkinetContext : DbContext
    {
        public SkinetContext(DbContextOptions<SkinetContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}