using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class NcmRepository : RepositoryBase<Ncm, long>, INcmRepository
{
    public NcmRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Ncm entity)
    {
        var dadosExistentes = await FindFirstAsync(x => x.ncm_id == entity.ncm_id,
            new string[] { "mvaorigemdestinos" });

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> UpsertRangeAsNoTrakingAsync(IEnumerable<Ncm> entities)
    {
        foreach (var entity in entities)
        {
            var dadosExistentes = await FindFirstAsync(c => c.ncm_id == entity.ncm_id);

            if (dadosExistentes == default)
            {
                await AddAsync(entity);
            }
            else
            {
                Mapper.Map(entity, dadosExistentes);
            }
        }

        return true;
    }


    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.ncm_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}