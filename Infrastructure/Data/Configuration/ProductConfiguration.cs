using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(p => p.Description).IsUnicode(false).IsRequired();

            builder.Property(p=> p.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(p=>p.PictureUrl).IsUnicode(false).IsRequired();

            builder.HasOne(x=>x.ProductType).WithMany().HasForeignKey(x=>x.ProductTypeId);

            builder.HasOne(x=>x.ProductBrand).WithMany().HasForeignKey(x=>x.ProductBrandId);
        }
    }
}