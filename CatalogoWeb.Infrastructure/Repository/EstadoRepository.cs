using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class EstadoRepository : RepositoryBase<Estado, int>, IEstadoRepository
{
    public EstadoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        

}