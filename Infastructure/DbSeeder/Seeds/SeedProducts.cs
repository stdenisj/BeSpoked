using AutoBogus;
using BeSpoked.Db;
using BeSpoked.Products.Entities;
using Bogus;

namespace DbSeeder.Seeds;

public class SeedProducts
{
    private readonly BeSpokedDbContext _dbContext;

    public SeedProducts(BeSpokedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var products = GetProduct().Generate(10);
        await _dbContext.Products.AddRangeAsync(products);
        await _dbContext.SaveChangesAsync();
    }

    public static Faker<Product> GetProduct()
        => new AutoFaker<Product>().CustomInstantiator(_ => new Product
            {
                Id = Guid.NewGuid(),
                Name = "",
                Manufacturer = "",
            })
            .RuleFor(p => p.Name, f => f.Vehicle.Model())
            .RuleFor(p => p.Manufacturer, f => f.Company.CompanyName())
            .RuleFor(p => p.Style, f => f.PickRandom<ProductStyle>())
            .RuleFor(p => p.PurchasePrice, f => f.Finance.Amount())
            .RuleFor(p => p.SalePrice, f => f.Finance.Amount())
            .RuleFor(p => p.QuantityOnHand, f => f.Random.Int(0, 10))
            .RuleFor(p => p.CommissionPercentage, f => f.Finance.Amount(0M, 1M));
}