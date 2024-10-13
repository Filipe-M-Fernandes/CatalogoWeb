using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class CidadeRepository : RepositoryBase<Cidade, int>, ICidadeRepository
{
    public CidadeRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        

}