#nullable enable
using BeSpoked.Common.EntityService.Entities;

namespace BeSpoked.Common.EntityService.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity: Entity
{
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default);
    Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);
}