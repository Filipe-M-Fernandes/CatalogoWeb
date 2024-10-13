using System.Linq.Expressions;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;

namespace CatalogoWeb.Domain.Abstractions.Repositories;

public interface IRepositoryBase<TEntity, TId> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(string[] expands = null);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string[] expands = null);
    Task<PagedModel<TEntity>> GetAllAsync(PagedParams pagedParams, string[] expands = null);
    Task<TEntity> GetByIdAsync(TId id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(IEnumerable<TEntity> entity);
    Task<bool> DeleteAsync(TId id);
    Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> UpsertAsync(TEntity entity);
    Task<bool> UpsertAsNoTrakingAsync(TEntity entity);
    Task<bool> UpsertRangeAsNoTrakingAsync(IEnumerable<TEntity> entities);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[] expands = null);
    Task<PagedModel<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, PagedParams pagedParams, string[] expands = null);
    Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicate, string[] expands = null, bool asnotracking = false);
}