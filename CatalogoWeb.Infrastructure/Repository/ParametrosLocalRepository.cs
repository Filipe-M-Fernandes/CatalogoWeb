﻿using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class ParametrosLocalRepository : RepositoryBase<ParametrosLocal, long>, IParametrosLocalRepository
{
    public ParametrosLocalRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(ParametrosLocal entity)
    {
        var dadosExistentes = await dbSet.Where(x => x.par_id == entity.par_id)
            .FirstOrDefaultAsync();

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    
    public override async Task<bool> UpsertAsNoTrakingAsync(ParametrosLocal entity)
    {
        var dadosExistentes = await FindFirstAsync(p => p.par_id == entity.par_id, default, true);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);
        return true;
    }
}