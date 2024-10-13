using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class PedidoItemRepository : RepositoryBase<PedidoItem, long>, IPedidoItemRepository
{
    public PedidoItemRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        
    public override async Task<bool> UpsertAsync(PedidoItem entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.pdi_id == entity.pdi_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
        
    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.pdi_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}