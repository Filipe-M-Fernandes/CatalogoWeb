using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IUnidadeMedidaService
    {
        Task<List<UnidadeMedida>> Listar();
    }
}
