using AutoMapper;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
using System.Linq.Expressions;
using CatalogoWeb.Core;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO.Command.SubGrupo;
using CatalogoWeb.Core.Extensions;

namespace CatalogoWeb.Services
{
    public class SubGrupoService: ISubGrupoService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;

        public SubGrupoService(IUnitOfWork unitOfWork, IMapper mapper, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }
        public Task<SubGrupo> BuscarAsync(long Id)
        {
            return _unitOfWork.SubGrupo.GetByIdAsync(Id);
        }

        public Task<PagedModel<SubGrupo>> Listar(FiltrosSubGrupo filtros, string[] expand, PagedParams paginacao)
        {
            var filtroQuery = MontarFiltro(filtros);
            return _unitOfWork.SubGrupo.FindAsync(filtroQuery, paginacao, new string[] { "grupo" });
        }

        public async Task<SubGrupo> Incluir(SubGrupoInsertCommand dados)
        {
            SubGrupo entidade = _mapper.Map<SubGrupo>(dados);

            if (!await _unitOfWork.SubGrupo.AddAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }
        public async Task<SubGrupo> Alterar(SubGrupoUpdateCommand dados)
        {
            SubGrupo entidade = _mapper.Map<SubGrupo>(dados);

            if (!await _unitOfWork.SubGrupo.UpsertAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }
        public async Task<bool> Excluir(long Id)
        {
            bool retorno = await _unitOfWork.SubGrupo.DeleteAsync(Id);
            await _unitOfWork.CommitAsync();
            return retorno;
        }
        private Expression<Func<SubGrupo, bool>> MontarFiltro(FiltrosSubGrupo filtros)
        {
            var expr = PredicateBuilder.True<SubGrupo>();
            expr = expr.And(g => g.grupo.emp_id == _dadosUsuarioLogado.CodigoEmpresa());

            if (filtros.Codigo.HasValue) expr = expr.And(x => x.sgp_id == filtros.Codigo);
            if (filtros.Nome.HasValue()) expr = expr.And(x => x.sgp_nome.ToLower().Contains(filtros.Nome.ToLower()));
            if (filtros.Ativo.HasValue) expr = expr.And(x => x.sgp_ativo == filtros.Ativo.Value);
            if (filtros.Filtro.HasValue()) expr = expr.And(x => x.sgp_nome.ToLower().Contains(filtros.Filtro.ToLower()) || x.sgp_id == Convert.ToInt32(TextoHelper.RetornaNumeros(filtros.Filtro)));
            if (filtros.CodigoGrupo.HasValue) expr = expr.And(x => x.grupo.gru_id == filtros.CodigoGrupo.Value);

            return expr;
        }

    }
}
