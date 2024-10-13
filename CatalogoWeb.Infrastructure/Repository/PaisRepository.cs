using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class PaisRepository : RepositoryBase<Pais, int>, IPaisRepository
{
    public PaisRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        
    public override async Task<bool> UpsertAsync(Pais entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.pse_id == entity.pse_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
        
    public override async Task<bool> DeleteAsync(int id)
    {
        var dadosExistentes = await dbSet.Where(x => x.pse_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}