namespace BeSpoked.Sales.Models;

public sealed record RecordSaleRequest( Guid SalesPersonId, Guid CustomerId, Guid ProductId);