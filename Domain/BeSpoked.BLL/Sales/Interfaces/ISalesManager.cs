using BeSpoked.Sales.Models;

namespace BeSpoked.Sales.Interfaces;

public interface ISalesManager
{
    Task<SaleSummary> RecordSale(RecordSaleRequest request, CancellationToken cancellationToken = default);
}