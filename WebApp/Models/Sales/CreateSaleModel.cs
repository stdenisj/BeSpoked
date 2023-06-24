using BeSpoked.Sales.Models;

namespace BeSpoked.Api.Models.Sales;

public class CreateSaleModel
{
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesPersonId { get; set; }

    public RecordSaleRequest ToRequest() => new(SalesPersonId, CustomerId, ProductId);
};