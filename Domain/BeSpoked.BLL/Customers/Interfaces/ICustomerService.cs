using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.Customers.Entities;
using BeSpoked.Customers.Models;

namespace BeSpoked.Customers.Interfaces;

public interface ICustomerService : IEntityService<Customer, CreateCustomerRequest, UpdateCustomerRequest>
{
}