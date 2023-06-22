using BeSpoked.Common.EntityService;
using BeSpoked.SalesTeam.Entities;
using BeSpoked.SalesTeam.Interfaces;
using BeSpoked.SalesTeam.Models;
using BeSpoked.SalesTeam.Validators;

namespace BeSpoked.SalesTeam;

public class SalesPersonService : EntityServiceBase<SalesPerson, CreateSalesPersonRequest, UpdateSalesPersonRequest, SalesPersonValidator>, ISalesPersonService
{
    public SalesPersonService(ISalesPersonRepository repository) : base(repository){}

    protected override SalesPerson CreateFromRequest(CreateSalesPersonRequest createRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            FirstName = createRequest.FirstName,
            LastName = createRequest.LastName,
            Phone = createRequest.Phone,
            Manager = createRequest.Manager,
            StartDate = DateTime.Now
        };

    protected override SalesPerson ApplyUpdate(SalesPerson entity, UpdateSalesPersonRequest updateRequest)
    {
        if (string.IsNullOrEmpty(updateRequest.FirstName))
            entity.FirstName = updateRequest.FirstName!;
        
        if (string.IsNullOrEmpty(updateRequest.LastName))
            entity.LastName = updateRequest.LastName!;
        
        if (string.IsNullOrEmpty(updateRequest.Phone))
            entity.Phone = updateRequest.Phone!;
        
        if (string.IsNullOrEmpty(updateRequest.Manager))
            entity.Manager = updateRequest.Manager!;

        if (updateRequest.TerminationDate != null)
            entity.TerminationDate = updateRequest.TerminationDate;

        return entity;
    }
}