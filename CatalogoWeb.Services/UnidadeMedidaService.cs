using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Services
{
    public class UnidadeMedidaService : IUnidadeMedidaService
    {
        private IUnitOfWork _uniOfWork;

        public UnidadeMedidaService(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<List<UnidadeMedida>> Listar()
        {
            return (await _uniOfWork.UnidadeMedida.FindAsync(u => string.IsNullOrEmpty(u.ump_descricao) == false)).ToList();
        }
    }
}
