using BeSpoked.Common.EntityService;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Interfaces;
using BeSpoked.Sales.Models;
using BeSpoked.Sales.Validators;

namespace BeSpoked.Sales;

public class SalesService : EntityServiceBase<Sale, CreateSaleRequest, UpdateSaleRequest, SaleValidator>, ISalesService
{
    private readonly ISalesRepository _repository;
    
    public SalesService(ISalesRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override Sale CreateFromRequest(CreateSaleRequest createRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            CustomerId = createRequest.CustomerId,
            SalesPersonId = createRequest.SalesPersonId,
            ProductId = createRequest.ProductId,
            SalesDate = DateTime.Now,
            CommissionAmount = createRequest.CommissionAmount,
            SalesPrice = createRequest.SalesPrice
        };

    protected override Sale ApplyUpdate(Sale entity, UpdateSaleRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SaleSummary>> GetSalesSummaries(CancellationToken cancellationToken = default)
        => _repository.GetSalesSummaries(cancellationToken);

    public Task<SaleSummary> GetSaleSummary(Guid id, CancellationToken cancellationToken = default)
        => _repository.GetSaleSummary(id, cancellationToken);
}