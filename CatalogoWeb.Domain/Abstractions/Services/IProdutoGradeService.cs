using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IProdutoGradeService
    {
        Task<List<ProdutoGrade>> BuscarGradeProduto(long produtoId);
    }
}
