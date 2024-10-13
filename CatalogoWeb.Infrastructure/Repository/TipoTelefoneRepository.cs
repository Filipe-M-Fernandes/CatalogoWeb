using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class TipoTelefoneRepository : RepositoryBase<TipoTelefone, int>, ITipoTelefoneRepository
{
    public TipoTelefoneRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

}
