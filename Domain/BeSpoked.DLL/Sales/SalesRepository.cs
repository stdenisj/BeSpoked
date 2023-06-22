using BeSpoked.Common.EntityService;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Sales;

public class SalesRepository : RepositoryBase<Sale>, ISalesRepository
{
    public SalesRepository(DbContext dbContext, RepositoryOptions<Sale>? options = null) : base(dbContext, options)
    {
    }
}