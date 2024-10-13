using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class StatusPedidoRepository : RepositoryBase<StatusPedido, long>, IStatusPedidoRepository
{
    public StatusPedidoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
    public override async Task<bool> UpsertAsync(StatusPedido entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.stp_id == entity.stp_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.stp_id == id).FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}
