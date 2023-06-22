#nullable enable
using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Common.EntityService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Common.EntityService;

public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly DbContext _dbContext;
    private readonly RepositoryOptions<TEntity>? _options;
    private readonly DbSet<TEntity> _set;
    protected readonly IQueryable<TEntity> _baseQuery;

    public RepositoryBase(DbContext dbContext, RepositoryOptions<TEntity>? options = null)
    {
        _dbContext = dbContext;
        _options = options;
        _set = _dbContext.Set<TEntity>();
        _baseQuery = options?.BaseQuery != null ? options.BaseQuery(_set) : _set;
    }
    
    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _baseQuery
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default)
        => await _baseQuery.FirstAsync((e) => e.Id == id ,cancellationToken);
    
    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default)
    {
        _set.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        if(_options?.BaseQuery == null)
            return entity;

        return await Get(entity.Id, cancellationToken);
    }
    
    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}