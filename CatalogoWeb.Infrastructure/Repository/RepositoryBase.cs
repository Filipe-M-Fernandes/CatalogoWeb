using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Infrastructure.Extensions;
using CatalogWeb.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogoWeb.Infrastructure.Repositories;

public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : class
{
    protected CatalogoDbContext Context;
    protected readonly IMapper Mapper;
    internal DbSet<TEntity> dbSet;

    public RepositoryBase(CatalogoDbContext context, IMapper mapper)
    {
        Context = context;
        dbSet = context.Set<TEntity>();
        Mapper = mapper;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] expands = null) =>
        await dbSet.AsNoTracking().Inflate(expands).ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string[] expands = null)
    {
        var query = dbSet.Where(predicate).Inflate(expands);
        return await query.ToListAsync();
    }

    public async Task<PagedModel<TEntity>> GetAllAsync(PagedParams pagedParams, string[] expands = null) =>
        await dbSet.AsNoTracking().Inflate(expands)
            .PaginateAsync(pagedParams.PageNumber, pagedParams.PageSize, pagedParams.Order);

    public virtual async Task<TEntity> GetByIdAsync(TId id) => await dbSet.FindAsync(id);

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }
    public virtual async Task<bool> AddRangeAsync(IEnumerable<TEntity> entity)
    {
        await dbSet.AddRangeAsync(entity);
        return true;
    }

    public virtual async Task<bool> DeleteAsync(TId id)
    {
        var registroExistente = await dbSet.FindAsync(id);

        if (registroExistente == default) return false;

        dbSet.Remove(registroExistente);

        return true;
    }

    public virtual async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any()) return false;

        dbSet.RemoveRange(entities);

        return true;
    }

    public virtual Task<bool> UpsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
    public virtual Task<bool> UpsertAsNoTrakingAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
    public virtual Task<bool> UpsertRangeAsNoTrakingAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[]? expands = null)
    {
        return await dbSet.AsNoTracking().Where(predicate).Inflate(expands).ToListAsync();
    }

    public async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicate, string[] expands = null, bool asNoTracking = false)
    {
        var query = dbSet.Where(predicate).Inflate(expands);

        if (asNoTracking)
            return await query.AsNoTracking().FirstOrDefaultAsync();
        else
            return await query.FirstOrDefaultAsync();
    }

    public async Task<PagedModel<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, PagedParams pagedParams,
        string[] expands = null) => await dbSet.AsNoTracking().Where(predicate).Inflate(expands)
        .PaginateAsync(pagedParams.PageNumber, pagedParams.PageSize, pagedParams.Order);
}
