#nullable enable
using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Common.EntityService.Models;

namespace BeSpoked.Common.EntityService.Interfaces;

public interface IEntityService<TEntity, in TCreateRequest, in TUpdateRequest> 
    where TEntity : Entity
    where TCreateRequest : ICreateEntityRequest 
    where TUpdateRequest : IUpdateEntityRequest
{
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default);
    Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> Create(TCreateRequest request, CancellationToken cancellationToken = default);
    Task<TEntity> Update(TEntity entity, TUpdateRequest request, CancellationToken cancellationToken = default);
}