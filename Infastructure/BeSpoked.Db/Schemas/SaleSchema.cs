using BeSpoked.Sales.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSpoked.Db.Schemas;

public class SaleSchema: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> entity)
    {
        entity.HasKey(e => e.Id);

        entity.HasIndex(e => e.CustomerId, "IX_Sales_CustomerId");

        entity.HasIndex(e => e.ProductId, "IX_Sales_ProductId");

        entity.HasIndex(e => e.SalesPersonId, "IX_Sales_SalesPersonId");

        entity.HasOne(d => d.Customer)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(d => d.Product)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(d => d.SalesPerson)
            .WithMany(p => p.Sales)
            .HasForeignKey(d => d.SalesPersonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}