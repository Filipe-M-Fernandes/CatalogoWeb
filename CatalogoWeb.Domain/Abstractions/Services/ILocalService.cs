using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface ILocalService
    {
        Task<List<Local>> ListarLocalUsuarioSP(FiltrosLocal filtros);
        Task<PagedModel<Local>> ListarLocalUsuario(FiltrosLocal filtros, PagedParams paginacao);
        Task<UsuarioDTO> SelecionarEmpresaLocal(SelecionaEmpresaLocal empresaLocal);
    }
}
