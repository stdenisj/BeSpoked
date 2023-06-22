#nullable enable
using BeSpoked.Common.EntityService.Entities;

namespace BeSpoked.Common.EntityService;

public class RepositoryOptions<TEntity> where TEntity: Entity
{
    public Func<IQueryable<TEntity>, IQueryable<TEntity>> ? BaseQuery { get; set; }
}