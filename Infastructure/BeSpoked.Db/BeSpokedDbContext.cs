using BeSpoked.Customers.Entities;
using BeSpoked.Db.Schemas;
using BeSpoked.Products.Entities;
using BeSpoked.Sales.Entities;
using BeSpoked.SalesTeam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Update.Internal;
using Microsoft.EntityFrameworkCore.Update;

namespace BeSpoked.Db;

public class BeSpokedDbContext : DbContext
{
    public BeSpokedDbContext()
    {
    }

    public BeSpokedDbContext(DbContextOptions<BeSpokedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<SalesPerson> SalesTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerSchema());
        modelBuilder.ApplyConfiguration(new ProductSchema());
        modelBuilder.ApplyConfiguration(new SaleSchema());
        modelBuilder.ApplyConfiguration(new SalesPersonSchema());
    }
}
