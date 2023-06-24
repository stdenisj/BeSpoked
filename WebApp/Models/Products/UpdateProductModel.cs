using BeSpoked.Products.Models;

namespace BeSpoked.Api.Models.Products;

public class UpdateProductModel
{
    public Guid Id { get; set; }
    public decimal SalesPrice { get; set; }
    public int Quantity { get; set; }

    public UpdateProductRequest ToRequest() => new() { QuantityOnHand = Quantity, SalePrice = SalesPrice };
}