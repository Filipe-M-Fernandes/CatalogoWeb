using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Services
{
    public class ListaPrecoService : IListaPrecoService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;

        public ListaPrecoService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task<List<ListaPreco>> Listar()
        {
            try
            {
                return (await _unitOfWork.ListaPreco.FindAsync(l => l.emp_id == _dadosUsuarioLogado.CodigoEmpresa() && l.ltp_ativa)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
