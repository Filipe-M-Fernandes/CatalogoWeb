using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IEmpresaService
    {
        Task<PagedModel<Empresa>> ListarEmpresasUsuario(FiltrosEmpresa filtros, PagedParams paginacao);
    }
}
