using System;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShipToAddress, x =>
            {
                x.WithOwner();
            });

            builder.Property(p => p.Status)
            .HasConversion(
                c => c.ToString(),
                c => (OrderStatus)Enum.Parse(typeof(OrderStatus), c)
            );
            
            builder.HasMany(o=>o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property(x=>x.Subtotal).HasColumnType("decimal(18,2)");
        }
    }
}