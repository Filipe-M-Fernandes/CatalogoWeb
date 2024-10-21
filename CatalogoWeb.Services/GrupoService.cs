using AutoMapper;
using CatalogoWeb.Core;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Core.Extensions;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.DTO.Command.Grupo;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Infrastructure;
using System.Linq.Expressions;

namespace CatalogoWeb.Services
{
    public class GrupoService: IGrupoService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;
        private IMapper _mapper;

        public GrupoService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuarioLogado;
            _mapper = mapper;
        }

        public Task<PagedModel<Grupo>> Buscar(FiltrosGrupoProduto filtros, PagedParams paginacao)
        {
            var filtroQuery = MontarFiltro(filtros);
            return _unitOfWork.GrupoProduto.FindAsync(filtroQuery, paginacao);
        }

        private Expression<Func<Grupo, bool>> MontarFiltro(FiltrosGrupoProduto filtros)
        {
            var expr = PredicateBuilder.True<Grupo>();
            expr = expr.And(x => x.emp_id == _dadosUsuarioLogado.CodigoEmpresa());
            if (filtros.CodigoGrupo.HasValue) expr = expr.And(x => x.gru_id == filtros.CodigoGrupo);
            if (filtros.Filtro.HasValue()) expr = expr.And(x => x.gru_nome.ToLower().Contains(filtros.Filtro.ToLower()));
            if (filtros.ApenasAtivos != null && filtros.ApenasAtivos == true) expr = expr.And(x => x.gru_ativo == true);

            return expr;
        }

        public async Task<Grupo> IncluirAsync(GrupoInsertCommand dados)
        {
            Grupo entidade = _mapper.Map<Grupo>(dados);
            entidade.emp_id = _dadosUsuarioLogado.CodigoEmpresa();

            if (!await _unitOfWork.GrupoProduto.AddAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Grupo> AlterarAsync(GrupoUpdateCommand dados)
        {
            Grupo entidade = _mapper.Map<Grupo>(dados);

            entidade.emp_id = _dadosUsuarioLogado.CodigoEmpresa();
            if (!await _unitOfWork.GrupoProduto.UpsertAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            bool retorno = await _unitOfWork.GrupoProduto.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return retorno;
        }
    }
}
