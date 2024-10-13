using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class EmpresaRepository : RepositoryBase<Empresa, int>, IEmpresaRepository
{
    public EmpresaRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        
    public override async Task<bool> UpsertAsync(Empresa entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.emp_id == entity.emp_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(Empresa entity)
    {
        var dadosExistentes = await FindFirstAsync(p => p.emp_id == entity.emp_id, default, true);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);
        return true;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        var dadosExistentes = await dbSet.Where(x => x.emp_id == id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}