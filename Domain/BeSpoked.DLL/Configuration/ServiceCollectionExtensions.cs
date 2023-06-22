using BeSpoked.Customers;
using BeSpoked.Customers.Interfaces;
using BeSpoked.Db;
using BeSpoked.Products;
using BeSpoked.Products.Interfaces;
using BeSpoked.Sales;
using BeSpoked.Sales.Interfaces;
using BeSpoked.SalesTeam;
using BeSpoked.SalesTeam.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeSpoked.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnectionString");

        services.AddDbContext<BeSpokedDbContext>(options =>
        {
            options.UseSqlite(dbConnectionString);
        });
        
        // Add customers
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        
        // Add Products
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        // Add Sales
        services.AddScoped<ISalesService, SalesService>();
        services.AddScoped<ISalesRepository, SalesRepository>();
        
        // Add SalesTeam
        services.AddScoped<ISalesPersonService, SalesPersonService>();
        services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();
        
        return services;
    }
}