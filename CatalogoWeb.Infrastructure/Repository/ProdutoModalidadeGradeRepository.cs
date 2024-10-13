using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogoWeb.Infrastructure.Repositories;
public class ProdutoModalidadeGradeRepository : RepositoryBase<ProdutoModalidadeGrade, long>, IProdutoModalidadeGradeRepository
{
    public ProdutoModalidadeGradeRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

   

}