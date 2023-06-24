using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Models;

namespace BeSpoked.Sales.Interfaces;

public interface ISalesRepository : IRepositoryBase<Sale>
{
    Task<IEnumerable<SaleSummary>> GetSalesSummaries(CancellationToken cancellationToken = default);
    Task<SaleSummary> GetSaleSummary(Guid id, CancellationToken cancellationToken = default);
}