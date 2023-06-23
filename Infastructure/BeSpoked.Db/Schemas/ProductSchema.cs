using BeSpoked.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSpoked.Db.Schemas;

public class ProductSchema: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(e => e.Id);
    }
}