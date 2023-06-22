using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.SalesTeam.Entities;
using BeSpoked.SalesTeam.Models;

namespace BeSpoked.SalesTeam.Interfaces;

public interface ISalesPersonService : IEntityService<SalesPerson, CreateSalesPersonRequest, UpdateSalesPersonRequest>
{
}