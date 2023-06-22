using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Sales.Entities;

namespace BeSpoked.Products.Entities;

public record Product : Entity
{
    public required string Name { get; set; }
    public required string Manufacturer { get; set; }
    public ProductStyle Style { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityOnHand { get; set; }
    public decimal CommissionPercentage { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}