using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class TipoEnderecoRepository : RepositoryBase<TipoEndereco, int>, ITipoEnderecoRepository
{
    public TipoEnderecoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
}