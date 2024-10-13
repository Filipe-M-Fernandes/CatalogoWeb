using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class LocalRepository : RepositoryBase<Local, long>, ILocalRepository
{
    public LocalRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Local entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.loc_id == entity.loc_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(Local entity)
    {
        var dadosExistentes = await FindFirstAsync(u => u.loc_id == entity.loc_id);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.loc_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }

    public async Task<Local> WhereLocalIncludeEmpresa(int empId, long locId) => 
        await dbSet.Where(x => x.emp_id == empId && x.loc_id == locId)
            .Include(x => x.empresa).SingleAsync();

}