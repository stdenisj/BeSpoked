using BeSpoked.Common.EntityService;
using BeSpoked.Db;
using BeSpoked.Products.Entities;
using BeSpoked.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Products;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(BeSpokedDbContext dbContext, RepositoryOptions<Product>? options = null) : base(dbContext, options)
    {
    }
}