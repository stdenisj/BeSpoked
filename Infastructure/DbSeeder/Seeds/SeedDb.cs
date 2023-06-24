using AutoBogus;
using BeSpoked.Customers.Entities;
using BeSpoked.Db;
using BeSpoked.Products.Entities;
using BeSpoked.Sales.Entities;
using BeSpoked.SalesTeam.Entities;
using Bogus;

namespace DbSeeder.Seeds;

public class SeedDb
{
    private readonly BeSpokedDbContext _dbContext;

    public SeedDb(BeSpokedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var salesTeam = GetSalesTeam().Generate(3);

        var manager = GetSalesTeam().Generate();
        manager.Manager = "Owner";
        
        foreach (var salesPerson in salesTeam)
        {
            var customer = GetCustomers().Generate();
            var product = GetProduct().Generate();
            var sale = new Sale
            {
                CustomerId = customer.Id,
                SalesPersonId = salesPerson.Id,
                ProductId = product.Id,
                SalesDate = customer.StartDate,
                CommissionAmount = decimal.Round(product.SalePrice * product.CommissionPercentage, 2, MidpointRounding.ToEven),
                SalesPrice = product.SalePrice
            };
            
            customer.Sales.Add(sale);
            product.Sales.Add(sale);
            salesPerson.Sales.Add(sale);
            salesPerson.Manager = $"{manager.FirstName} {manager.LastName}";
            
            _dbContext.Customers.Add(customer);
            _dbContext.SalesTeams.Add(salesPerson);
            _dbContext.Products.Add(product);
            _dbContext.Sales.Add(sale);
            await _dbContext.SaveChangesAsync();
        }

        var products = GetProduct().Generate(3);
        _dbContext.Products.AddRange(products);

        var newCustomers = GetCustomers().Generate(3);
        _dbContext.Customers.AddRange(newCustomers);
        _dbContext.SalesTeams.Add(manager);
        
        await _dbContext.SaveChangesAsync();
    }

    private static Faker<Product> GetProduct()
        => new AutoFaker<Product>().CustomInstantiator(_ => new Product
            {
                Id = Guid.NewGuid(),
                Name = "",
                Manufacturer = "",
                Sales = new List<Sale>()
            })
            .RuleFor(p => p.Name, f => f.Vehicle.Model())
            .RuleFor(p => p.Manufacturer, f => f.Company.CompanyName())
            .RuleFor(p => p.Style, f => f.PickRandom<ProductStyle>())
            .RuleFor(p => p.PurchasePrice, f => f.Finance.Amount())
            .RuleFor(p => p.SalePrice, f => f.Finance.Amount())
            .RuleFor(p => p.QuantityOnHand, f => f.Random.Int(0, 10))
            .RuleFor(p => p.CommissionPercentage, f => f.Finance.Amount(0.05M, 1M))
            .RuleFor(p => p.Sales, new List<Sale>());

    private static Faker<Customer> GetCustomers()
        => new AutoFaker<Customer>().CustomInstantiator(_ => new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                Phone = "",
                Sales = new List<Sale>()
            })
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName)
            .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(p => p.StartDate, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
            .RuleFor(p => p.Sales, new List<Sale>());
    
    private static Faker<SalesPerson> GetSalesTeam()
        => new AutoFaker<SalesPerson>().CustomInstantiator(_ => new SalesPerson
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                Phone = "",
                Manager = "",
                TerminationDate = null,
                Sales = new List<Sale>()
            })
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName)
            .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(p => p.Manager, f => f.Person.FullName)
            .RuleFor(p => p.StartDate, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
            .RuleFor(p => p.TerminationDate, f=> null)
            .RuleFor(p => p.Sales, new List<Sale>());
    
}