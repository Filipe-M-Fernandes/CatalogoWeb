using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class ListaPrecoItemRepository : RepositoryBase<ListaPrecoItem, long>, IListaPrecoItemRepository
{
    public ListaPrecoItemRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
    public override async Task<bool> UpsertAsync(ListaPrecoItem entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.lpi_id == entity.lpi_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(ListaPrecoItem entity)
    {
        var dadosExistentes = await FindFirstAsync(c => c.lpi_id == entity.lpi_id, default, false);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.lpi_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}
