using BeSpoked.Common.EntityService;
using BeSpoked.Products.Entities;
using BeSpoked.Products.Interfaces;
using BeSpoked.Products.Models;
using BeSpoked.Products.Validators;

namespace BeSpoked.Products;

public class ProductService : EntityServiceBase<Product, CreateProductRequest, UpdateProductRequest, ProductValidator>, IProductService
{
    public ProductService(IProductRepository repository) : base(repository) {}

    protected override Product CreateFromRequest(CreateProductRequest createRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = createRequest.Name,
            Manufacturer = createRequest.Manufacturer,
            Style = createRequest.Style,
            PurchasePrice = createRequest.PurchasePrice,
            SalePrice = createRequest.SalePrice,
            QuantityOnHand = createRequest.QuantityOnHand,
            CommissionPercentage = createRequest.CommissionPercentage
        };

    protected override Product ApplyUpdate(Product entity, UpdateProductRequest updateRequest)
    {
        if (!string.IsNullOrEmpty(updateRequest.Name))
            entity.Name = updateRequest.Name;
        
        if (!string.IsNullOrEmpty(updateRequest.Manufacturer))
            entity.Manufacturer = updateRequest.Manufacturer;

        if (updateRequest.Style != null)
            entity.Style = updateRequest.Style.Value;

        if (updateRequest.PurchasePrice != null)
            entity.PurchasePrice = updateRequest.PurchasePrice.Value;

        if (updateRequest.SalePrice != null)
            entity.SalePrice = updateRequest.SalePrice.Value;

        if (updateRequest.CommissionPercentage != null)
            entity.CommissionPercentage = updateRequest.CommissionPercentage.Value;

        if (updateRequest.QuantityOnHand != null)
            entity.QuantityOnHand = updateRequest.QuantityOnHand.Value;

        return entity;
    }
}