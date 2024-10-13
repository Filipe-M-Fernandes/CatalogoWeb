using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class PedidoRepository : RepositoryBase<Pedido, long>, IPedidoRepository
{
    public PedidoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Pedido entity)
    {
        var dadosExistentes = await FindFirstAsync(c => c.ped_id == entity.ped_id,
            new string[] { "pedidohistoricos", "pedidoformapgtos", "pedidoitens" });

        entity.ped_datainclusao = dadosExistentes.ped_datainclusao;
        entity.ped_dataprevisaoentrega = dadosExistentes.ped_dataprevisaoentrega;
        entity.ped_datavalidade = dadosExistentes.ped_datavalidade;
        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.ped_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(Pedido entity)
    {
        var dadosExistentes = await FindFirstAsync(p => p.ped_id == entity.ped_id, default, true);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);
        return true;
    }
}