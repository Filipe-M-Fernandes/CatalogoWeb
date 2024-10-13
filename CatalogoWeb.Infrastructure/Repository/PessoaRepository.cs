using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class PessoaRepository : RepositoryBase<Pessoa, long>, IPessoaRepository
{
    public PessoaRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        
    public override async Task<bool> UpsertAsync(Pessoa entity)
    {
        var dadosExistentes = await FindFirstAsync(q => q.pes_id == entity.pes_id, new string[] { "fornecedores", "transportadores", "clientes", "funcionarios", "vendedores", "pessoatelefones",
            "pessoaenderecos", "pessoaemails"});

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
        
    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await dbSet.Where(x => x.pes_id == id)
            .FirstOrDefaultAsync();       

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}