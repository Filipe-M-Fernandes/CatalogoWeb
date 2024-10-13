using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class UsuarioRepository : RepositoryBase<Usuario, long>, IUsuarioRepository
{
    public UsuarioRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Usuario entity)
    {
        var dadosExistentes = await FindFirstAsync(u => u.usu_id == entity.usu_id, new string[] { "usuarioslocais" });

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(Usuario entity)
    {
        var dadosExistentes = await FindFirstAsync(u => u.usu_id == entity.usu_id);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.usu_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }

}