using BeSpoked.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSpoked.Db.Schemas;

public class ProductSchema: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("Products");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.PurchasePrice).HasPrecision(19, 2);
        entity.Property(e => e.SalePrice).HasPrecision(19, 2);
        entity.Property(e => e.CommissionPercentage).HasPrecision(1, 2);
    }
}