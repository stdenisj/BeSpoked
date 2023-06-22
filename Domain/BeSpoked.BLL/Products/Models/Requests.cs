using BeSpoked.Common.EntityService.Models;
using BeSpoked.Products.Entities;

namespace BeSpoked.Products.Models;

public record CreateProductRequest : ICreateEntityRequest
{
    public required string Name { get; set; }
    public required string Manufacturer { get; set; }
    public ProductStyle Style { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityOnHand { get; set; }
    public decimal CommissionPercentage { get; set; }
};

public record UpdateProductRequest : IUpdateEntityRequest
{
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public ProductStyle? Style { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? SalePrice { get; set; }
    public int? QuantityOnHand { get; set; }
    public decimal? CommissionPercentage { get; set; }
};