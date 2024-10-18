using AutoMapper;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
using System.Linq.Expressions;
using CatalogoWeb.Core;
using Microsoft.EntityFrameworkCore;
using CatalogoWeb.Core.Extensions;

namespace CatalogoWeb.Services
{
    public class EmpresaService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;

        public EmpresaService(IUnitOfWork unitOfWork,IMapper mapper, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task<PagedModel<Empresa>> ListarEmpresasUsuario(FiltrosEmpresa filtros, string[] expand, PagedParams paginacao)
        {
            long codigoUsuarioLogado = _dadosUsuarioLogado.IdUsuario();
            var filtroQuery = MontarFiltroEmpresas(filtros);
            filtroQuery = filtroQuery.And(u => u.locais.Any(u => u.usuarioslocais.Any(u => u.usu_id == codigoUsuarioLogado)));
            return await _unitOfWork.Empresas.FindAsync(filtroQuery, paginacao);
        }

        private Expression<Func<Empresa, bool>> MontarFiltroEmpresas(FiltrosEmpresa filtros)
        {
            var expr = PredicateBuilder.True<Empresa>();

            if (filtros.IdEmpresa.HasValue) expr = expr.And(x => x.emp_id == filtros.IdEmpresa.Value);
            if (filtros.Ativo.HasValue) expr = expr.And(x => x.emp_ativa == filtros.Ativo.Value);
            if (filtros.NomeFantasia.HasValue()) expr = expr.And(x => x.emp_nomefantasia.ToLower().Contains(filtros.NomeFantasia.ToLower()));
            if (filtros.RazaoSocial.HasValue()) expr = expr.And(x => x.emp_razaosocial.ToLower().Contains(filtros.RazaoSocial.ToLower()));
            if (filtros.Filtro.HasValue()) expr = expr.And(x =>x.emp_nomefantasia.ToLower().Contains(filtros.Filtro.ToLower()) || x.emp_razaosocial.ToLower().Contains(filtros.Filtro.ToLower()));

            return expr;
        }
    }
}
