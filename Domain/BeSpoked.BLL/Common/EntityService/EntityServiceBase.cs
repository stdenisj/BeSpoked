#nullable enable
using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Common.EntityService.Interfaces;
using BeSpoked.Common.EntityService.Models;
using FluentValidation;

namespace BeSpoked.Common.EntityService;

public abstract class EntityServiceBase<TEntity, TCreateRequest, TUpdateRequest, TValidator> : 
    IEntityService<TEntity, TCreateRequest, TUpdateRequest> 
    where TEntity : Entity
    where TCreateRequest : ICreateEntityRequest
    where TUpdateRequest : IUpdateEntityRequest
    where TValidator : AbstractValidator<TEntity>, new()
{
    private readonly IRepositoryBase<TEntity> _repository;
    private readonly TValidator _validator = new ();

    protected EntityServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
        => _repository.GetAll(cancellationToken);

    public Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default)
        => _repository.Get(id, cancellationToken);
    protected abstract TEntity CreateFromRequest(TCreateRequest createRequest);
    
    public async Task<TEntity> Create(TCreateRequest request, CancellationToken cancellationToken = default)
    {
        var entity = CreateFromRequest(request);
        Validate(entity, cancellationToken);
        return await _repository.Create(entity, cancellationToken);
    }

    protected abstract TEntity ApplyUpdate(TEntity entity, TUpdateRequest updateRequest);

    public async Task<TEntity> Update(TEntity entity, TUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var updatedEntity = ApplyUpdate(entity, request);
        return await Update(updatedEntity, cancellationToken);
    }

    protected async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        Validate(entity, cancellationToken);
        await _repository.Update(entity, cancellationToken);
        return entity;
    }
    private void Validate(TEntity entity, CancellationToken cancellationToken)
    {
        var errors = _validator.GetModelValidationErrors(entity).ToList();
        if (errors.Any())
            throw new ModelValidationException(errors);
    }
}