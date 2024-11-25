using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoWeb.Infrastructure.Repository
{
    public class GrupoAcessoRespository : RepositoryBase<GruposAcesso,long>, IGruposAcessoRepository
    {
        public GrupoAcessoRespository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<bool> UpsertAsync(GruposAcesso entity)
        {
            var dadosExistentes = await FindFirstAsync(x => x.gac_id == entity.gac_id);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }
        public override async Task<bool> UpsertAsNoTrakingAsync(GruposAcesso entity)
        {
            var dadosExistentes = await FindFirstAsync(p => p.gac_id == entity.gac_id, default, true);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var dadosExistentes = await dbSet.Where(x => x.gac_id == id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default) return false;

            dbSet.Remove(dadosExistentes);

            return true;
        }
    }
}
