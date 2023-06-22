using BeSpoked.Common.EntityService;
using BeSpoked.SalesTeam.Entities;
using BeSpoked.SalesTeam.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.SalesTeam;

public class SalesPersonRepository : RepositoryBase<SalesPerson>, ISalesPersonRepository
{
    public SalesPersonRepository(DbContext dbContext, RepositoryOptions<SalesPerson>? options = null) : base(dbContext, options)
    {
    }
}