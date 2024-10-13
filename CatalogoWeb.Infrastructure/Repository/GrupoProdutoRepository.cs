using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class GrupoProdutoRepository : RepositoryBase<Grupo, long>, IGrupoProdutoRepository
{
    public GrupoProdutoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Grupo entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.gru_id == entity.gru_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);
            
        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.gru_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}