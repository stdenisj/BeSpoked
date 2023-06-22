using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.Sales.Entities;
using BeSpoked.Sales.Models;

namespace BeSpoked.Sales.Interfaces;

public interface ISalesService : IEntityService<Sale, CreateSaleRequest, UpdateSaleRequest>
{
}