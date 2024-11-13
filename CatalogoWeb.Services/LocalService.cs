using AutoMapper;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
using CatalogoWeb.Infrastructure.Context;
using CatalogoWeb.Core;
using System.Linq.Expressions;
using CatalogoWeb.Core.Extensions;
using CatalogoWeb.Domain.Abstractions.Services;

namespace CatalogoWeb.Services
{
    public class LocalService : ILocalService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;
        public LocalService(IUnitOfWork unitOfWork, IMapper mapper, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task<PagedModel<Local>> ListarLocalUsuario(FiltrosLocal filtros, PagedParams paginacao)
        {
            var filtro = MontarFiltroLocais(filtros);
            if (filtros.idUser != 0)
            {
                filtro = filtro.And(u => u.usuarioslocais.Any(i => i.usu_id == filtros.idUser));
                return await _unitOfWork.Locais.FindAsync(filtro, paginacao);
            }

            filtro = filtro.And(u => u.usuarioslocais.Any(i => i.usu_id == _dadosUsuarioLogado.IdUsuario()));
            return await _unitOfWork.Locais.FindAsync(filtro, paginacao);
        }
        public async Task<List<Local>> ListarLocalUsuarioSP(FiltrosLocal filtros)
        {
            var filtro = MontarFiltroLocais(filtros);
            if (filtros.idUser != 0)
            {
                filtro = filtro.And(u => u.usuarioslocais.Any(i => i.usu_id == filtros.idUser));
                return (await _unitOfWork.Locais.FindAsync(filtro)).ToList();
            }

            filtro = filtro.And(u => u.usuarioslocais.Any(i => i.usu_id == _dadosUsuarioLogado.IdUsuario()));
            return (await _unitOfWork.Locais.FindAsync(filtro)).ToList();
        }

        public async Task<UsuarioDTO> SelecionarEmpresaLocal(SelecionaEmpresaLocal empresaLocal)
        {
            var user = await _unitOfWork.Usuarios.GetByIdAsync(_dadosUsuarioLogado.IdUsuario());

            if (user == null)
                return null;

            UsuarioDTO usuarioDTO = _mapper.Map<UsuarioDTO>(user);

            var local = await _unitOfWork.Locais.WhereLocalIncludeEmpresa(empresaLocal.emp_id, empresaLocal.loc_id);
            if (local != null)
            {
                _mapper.Map(local, usuarioDTO);
            }
            return usuarioDTO;
        }

        private Expression<Func<Local, bool>> MontarFiltroLocais(FiltrosLocal filtros)
        {
            var expr = PredicateBuilder.True<Local>();

            expr = expr.And(x => x.emp_id == (int)filtros.CodigoEmpresa);
            if (filtros.Codigo.HasValue()) expr = expr.And(x => x.loc_codigo == filtros.Codigo);
            if (filtros.Descricao.HasValue()) expr = expr.And(x => x.loc_descricao.ToLower().Contains(filtros.Descricao.ToLower()));
            if (filtros.CNPJ.HasValue()) expr = expr.And(x => x.loc_cnpj.Contains(filtros.CNPJ));
            if (filtros.Ativo.HasValue) expr = expr.And(x => x.loc_ativo == filtros.Ativo.Value);
            if (filtros.Matriz.HasValue) expr = expr.And(x => x.loc_matriz == filtros.Matriz.Value);
            if (filtros.NomeFantasia.HasValue()) expr = expr.And(x => x.loc_nomefantasia.ToLower().Contains(filtros.NomeFantasia.ToLower()));
            if (filtros.Filtro.HasValue()) expr = expr.And(x => x.loc_nomefantasia.ToLower().Contains(filtros.Filtro.ToLower()) || x.loc_descricao.ToLower().Contains(filtros.Filtro.ToLower()));

            return expr;
        }


    }
}
