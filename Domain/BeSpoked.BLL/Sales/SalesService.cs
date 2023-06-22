using BeSpoked.Common.EntityService;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Interfaces;
using BeSpoked.Sales.Models;
using BeSpoked.Sales.Validators;

namespace BeSpoked.Sales;

public class SalesService : EntityServiceBase<Sale, CreateSaleRequest, UpdateSaleRequest, SaleValidator>, ISalesService
{
    public SalesService(ISalesRepository repository) : base(repository)
    {
    }

    protected override Sale CreateFromRequest(CreateSaleRequest createRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            CustomerId = createRequest.CustomerId,
            SalesPersonId = createRequest.SalesPersonId,
            ProductId = createRequest.ProductId,
            SalesDate = DateTime.Now,
        };

    protected override Sale ApplyUpdate(Sale entity, UpdateSaleRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}