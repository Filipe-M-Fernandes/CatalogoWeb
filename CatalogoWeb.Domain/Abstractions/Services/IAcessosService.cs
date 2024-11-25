using CatalogoWeb.Domain.DTO;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IAcessosService
    {
        Task AcessoProduto(long produtoId, long? gradeId);
        Task AcessoGrupo(long grupoId);
        Task<BuscarAcessosDTO> BuscarTopAcessos();
    }
}
