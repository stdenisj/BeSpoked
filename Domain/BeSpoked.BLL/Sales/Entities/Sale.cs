using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Customers.Entities;
using BeSpoked.Products.Entities;
using BeSpoked.SalesTeam.Entities;

namespace BeSpoked.Sales.Entities;

public record Sale : Entity
{
    public required Guid CustomerId { get; set; }
    public required Guid SalesPersonId { get; set; }
    public required Guid ProductId { get; set; }
    public required DateTime SalesDate { get; set; }
    public required decimal CommissionAmount { get; set; }
    public required decimal SalesPrice { get; set; }
    public virtual SalesPerson SalesPerson { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
};