using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.Infrastructure.Repositories;

public class UsuarioAcessoRepository : RepositoryBase<UsuarioAcesso, long>, IUsuarioAcessoRepository
{
    public UsuarioAcessoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(UsuarioAcesso entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.uac_id == entity.uac_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.uac_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}
