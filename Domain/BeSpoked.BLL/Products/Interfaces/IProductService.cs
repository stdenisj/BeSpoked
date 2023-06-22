using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.Products.Entities;
using BeSpoked.Products.Models;

namespace BeSpoked.Products.Interfaces;

public interface IProductService : IEntityService<Product, CreateProductRequest, UpdateProductRequest>
{
}