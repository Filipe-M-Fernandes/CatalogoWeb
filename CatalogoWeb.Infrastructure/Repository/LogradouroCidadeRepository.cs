using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class LogradouroCidadeRepository : RepositoryBase<LogradouroCidade, long>, ILogradouroCidadeRepository
{
    public LogradouroCidadeRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        

}