using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Services
{
    public class ListaPrecoItemService : IListaPrecoItemService
    {
        private IUnitOfWork _unitOfWork;
        private IDadosUsuarioLogado _dadosUsuarioLogado;

        public ListaPrecoItemService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuariLogado)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuariLogado;
        }

        public async Task<List<ListaPrecoItem>> Listar(long proId)
        {
            return (await _unitOfWork.ListaPrecoItem.FindAsync(l => l.pro_id == proId, new string[] { "listapreco", })).ToList();
        }
    }
}
