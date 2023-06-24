using BeSpoked.Common.EntityService;
using BeSpoked.Customers.Entities;
using BeSpoked.Customers.Interfaces;
using BeSpoked.Db;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Customers;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(BeSpokedDbContext dbContext, RepositoryOptions<Customer>? options = null) : base(dbContext, options)
    {
    }
}