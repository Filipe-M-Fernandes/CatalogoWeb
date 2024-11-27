using AutoMapper;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Services
{
    public class ProdutoGradeService : IProdutoGradeService
    {

        private IUnitOfWork _unitOfWork;
        private IDadosUsuarioLogado _dadosUsuarioLogado;
        private IMapper _mapper;

        public ProdutoGradeService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuarioLogado;
            _mapper = mapper;
        }

        public async Task<List<ProdutoGrade>> BuscarGradeProduto(long produtoId)
        {
            try
            {

                return (await _unitOfWork.ProdutoGrade.FindAsync(p => p.pro_id == produtoId)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
