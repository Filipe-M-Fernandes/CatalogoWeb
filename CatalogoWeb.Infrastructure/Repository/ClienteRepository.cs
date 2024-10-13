using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class ClienteRepository : RepositoryBase<Cliente, long>, IClienteRepository
{
    public ClienteRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

    public override async Task<bool> UpsertAsync(Cliente entity)
    {
        var dadosExistentes = await FindFirstAsync(c => c.cli_id == entity.cli_id,
            new string[] { "clientecampopersonalizados", "pessoaautorizada", "pessoa.pessoatelefones", "pessoa.pessoaemails", "pessoa.pessoaoutrocontatos","pessoa.pessoaenderecos.pessoafisicainscestaduais",
                "pessoa.pessoafisicas", "pessoa.pessoafisicas.pessoanacionalidades", "pessoa.pessoafisicas.pessoasocupacoes","pessoa.pessoaenderecos" });

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }
    public override async Task<bool> UpsertAsNoTrakingAsync(Cliente entity)
    {
        var dadosExistentes = await FindFirstAsync(c => c.cli_id == entity.cli_id);

        if (dadosExistentes == default)
            return await AddAsync(entity);

        Mapper.Map(entity, dadosExistentes);

        return true;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var dadosExistentes = await FindFirstAsync(c => c.cli_id == id,
            new string[] { "clientecampopersonalizados", "pessoaautorizada", "pessoa.pessoatelefones", "pessoa.pessoaemails", "pessoa.pessoaoutrocontatos","pessoa.pessoaenderecos.pessoafisicainscestaduais",
                "pessoa.pessoafisicas", "pessoa.pessoafisicas.pessoanacionalidades", "pessoa.pessoafisicas.pessoasocupacoes","pessoa.pessoaenderecos", "analisecreditos" });

        if (dadosExistentes == default) return false;

        dbSet.Remove(dadosExistentes);

        return true;
    }
}