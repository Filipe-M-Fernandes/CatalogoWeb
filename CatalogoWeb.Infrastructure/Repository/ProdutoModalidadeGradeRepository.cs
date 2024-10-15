using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;
public class ProdutoModalidadeGradeRepository : RepositoryBase<ProdutoModalidadeGrade, long>, IProdutoModalidadeGradeRepository
{
    public ProdutoModalidadeGradeRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

   

}