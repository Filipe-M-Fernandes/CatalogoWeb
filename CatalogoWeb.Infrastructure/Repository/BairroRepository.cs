using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class BairroRepository : RepositoryBase<Bairro, long>, IBairroRepository
{
    public BairroRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        
    public override async Task<bool> UpsertAsync(Bairro entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.bai_id == entity.bai_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
        
    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.bai_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}