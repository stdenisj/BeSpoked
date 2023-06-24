using BeSpoked.Common.EntityService;
using BeSpoked.Db;
using BeSpoked.SalesTeam.Entities;
using BeSpoked.SalesTeam.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.SalesTeam;

public class SalesPersonRepository : RepositoryBase<SalesPerson>, ISalesPersonRepository
{
    public SalesPersonRepository(BeSpokedDbContext dbContext) : base(dbContext)
    {
    }
}