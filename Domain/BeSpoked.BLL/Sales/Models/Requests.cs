using BeSpoked.Common.EntityService.Models;
using BeSpoked.Customers.Entities;
using BeSpoked.Products.Entities;
using BeSpoked.SalesTeam.Entities;

namespace BeSpoked.Sales.Models;

public sealed record CreateSaleRequest : ICreateEntityRequest
{
    public required Guid SalesPersonId { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid ProductId { get; set; }
}

public sealed record UpdateSaleRequest : IUpdateEntityRequest;