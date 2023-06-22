using BeSpoked.Common.EntityService;
using BeSpoked.Customers.Entities;
using BeSpoked.Customers.Interfaces;
using BeSpoked.Customers.Models;
using BeSpoked.Customers.Validators;

namespace BeSpoked.Customers;

public class CustomerService : EntityServiceBase<Customer, CreateCustomerRequest, UpdateCustomerRequest, CustomerValidator>, ICustomerService
{
    public CustomerService(ICustomerRepository repository) : base(repository) { }

    protected override Customer CreateFromRequest(CreateCustomerRequest createRequest)
        => new()
        {
            Id = Guid.NewGuid(),
            FirstName = createRequest.FirstName,
            LastName = createRequest.LastName,
            Phone = createRequest.Phone,
            StartDate = DateTime.Now
        };

    protected override Customer ApplyUpdate(Customer entity, UpdateCustomerRequest updateRequest)
    {
        if (string.IsNullOrEmpty(updateRequest.FirstName))
            entity.FirstName = updateRequest.FirstName!;
        
        if (string.IsNullOrEmpty(updateRequest.LastName))
            entity.LastName = updateRequest.LastName!;
        
        if (string.IsNullOrEmpty(updateRequest.Phone))
            entity.Phone = updateRequest.Phone!;
        
        return entity;
    }
}