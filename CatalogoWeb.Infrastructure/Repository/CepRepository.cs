using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class CepRepository : RepositoryBase<Cep, int>, ICepRepository
{
    public CepRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        

}