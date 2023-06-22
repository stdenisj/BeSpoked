using BeSpoked.Common.EntityService;
using BeSpoked.Products.Entities;
using BeSpoked.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Products;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(DbContext dbContext, RepositoryOptions<Product>? options = null) : base(dbContext, options)
    {
    }
}