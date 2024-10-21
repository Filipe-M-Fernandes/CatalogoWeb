using CatalogoWeb.Core;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Core.Extensions;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Infrastructure;
using System.Linq.Expressions;

namespace CatalogoWeb.Services
{
    public class MarcaService : IMarcaService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;

        public MarcaService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task<Marca> Incluir(Marca entidade)
        {
            entidade.emp_id = _dadosUsuarioLogado.CodigoEmpresa();
            if (!await _unitOfWork.Marcas.AddAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Marca> Alterar(Marca entidade)
        {
            entidade.emp_id = _dadosUsuarioLogado.CodigoEmpresa();
            if (!await _unitOfWork.Marcas.UpsertAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> Excluir(long Id)
        {
            bool retorno = await _unitOfWork.Marcas.DeleteAsync(Id);
            await _unitOfWork.CommitAsync();
            return retorno;
        }

        public Task<Marca> BuscarAsync(long Id)
        {
            return _unitOfWork.Marcas.GetByIdAsync(Id);
        }

        public Task<PagedModel<Marca>> Listar(FiltrosMarca filtros, PagedParams paginacao)
        {
            var filtroQuery = MontarFiltroMarcas(filtros);
            return _unitOfWork.Marcas.FindAsync(filtroQuery, paginacao);
        }

        private Expression<Func<Marca, bool>> MontarFiltroMarcas(FiltrosMarca filtros)
        {
            var expr = PredicateBuilder.True<Marca>();

            expr = expr.And(x => x.emp_id == _dadosUsuarioLogado.CodigoEmpresa());
            if (filtros.Codigo.HasValue) expr = expr.And(x => x.mar_id == filtros.Codigo.Value);
            if (filtros.Nome.HasValue()) expr = expr.And(x => x.mar_nome.ToLower().Contains(filtros.Nome.ToLower()));
            if (filtros.Codigo.HasValue && filtros.Ativa.HasValue) expr = expr.And(x => x.mar_ativa == filtros.Ativa.Value);
            if (filtros.Filtro.HasValue()) expr = expr.And(x => x.mar_nome.ToLower().Contains(filtros.Filtro.ToLower()) || x.mar_id == Convert.ToInt32(TextoHelper.RetornaNumeros(filtros.Filtro)));
            return expr;
        }
    }
}
