using BeSpoked.Common.EntityService;
using BeSpoked.Db;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Interfaces;
using BeSpoked.Sales.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Sales;

public class SalesRepository : RepositoryBase<Sale>, ISalesRepository
{
    private readonly BeSpokedDbContext _dbContext;
    public SalesRepository(BeSpokedDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SaleSummary>> GetSalesSummaries(CancellationToken cancellationToken)
    {
        return await _dbContext.Sales
            .Include(s => s.SalesPerson)
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .Select(s => new SaleSummary(
                s.Id,
                s.SalesDate,
                s.SalesPrice,
                s.Customer.FullName,
                s.SalesPerson.FullName,
                s.CommissionAmount,
                s.Product.Name,
                s.Product.Manufacturer)
            ).ToListAsync(cancellationToken);
    }
    
    public async Task<SaleSummary> GetSaleSummary(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Sales
            .Where(s => s.Id == id)
            .Include(s => s.SalesPerson)
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .Select(s => new SaleSummary(
                s.Id,
                s.SalesDate,
                s.Product.SalePrice,
                s.Customer.FullName,
                s.SalesPerson.FullName,
                s.CommissionAmount,
                s.Product.Name,
                s.Product.Manufacturer)
            ).SingleAsync(cancellationToken);
    }
}