using BeSpoked.SalesTeam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSpoked.Db.Schemas;

public class SalesPersonSchema: IEntityTypeConfiguration<SalesPerson>
{
    public void Configure(EntityTypeBuilder<SalesPerson> entity)
    {
        entity.ToTable("SalesTeam");
        
        entity.HasKey(e => e.Id);

    }
}