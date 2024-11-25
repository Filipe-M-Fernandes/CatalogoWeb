using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
using CatalogoWeb.Infrastructure.Data;

namespace CatalogoWeb.Services
{
    public class AcessosService : IAcessosService
    {
        private IUnitOfWork _unitOfWork;
        private IDadosUsuarioLogado _dadosUsuarioLogado;

        public AcessosService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _unitOfWork = unitOfWork;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task AcessoProduto(long produtoId, long? gradeId)
        {
            int empId = _dadosUsuarioLogado.CodigoEmpresa();
            Produto prod = await _unitOfWork.Produto.FindFirstAsync(p => p.pro_id == produtoId);
            ProdutosAcesso proAcesso = new ProdutosAcesso();
            if (gradeId == null)
            {
                proAcesso = await _unitOfWork.ProdutosAcesso.FindFirstAsync(p => p.emp_id == _dadosUsuarioLogado.CodigoEmpresa() && p.pro_id == produtoId);
            }
            else
            {
                proAcesso = await _unitOfWork.ProdutosAcesso.FindFirstAsync(p => p.emp_id == _dadosUsuarioLogado.CodigoEmpresa() && p.pro_id == produtoId && p.prg_id == gradeId);
            }
            if (proAcesso == null)
            {
                proAcesso = new ProdutosAcesso()
                {
                    emp_id = _dadosUsuarioLogado.CodigoEmpresa(),
                    pro_id = produtoId,
                    pac_visitas = 1,
                    prg_id = gradeId
                };
                await _unitOfWork.ProdutosAcesso.AddAsync(proAcesso);
            }
            else
            {
                proAcesso.pac_visitas = proAcesso.pac_visitas + 1;
                await _unitOfWork.ProdutosAcesso.UpsertAsync(proAcesso);
            }
            await _unitOfWork.CommitAsync();
            await AcessoGrupo( (long)prod.gru_id);
        }

        public async Task AcessoGrupo( long grupoId)
        {
            int empId = _dadosUsuarioLogado.CodigoEmpresa();
            GruposAcesso gruAcesso = new GruposAcesso();
            gruAcesso = await _unitOfWork.GruposAcesso.FindFirstAsync(g => g.emp_id == _dadosUsuarioLogado.CodigoEmpresa() && g.gru_id == grupoId);
            if (gruAcesso == null)
            {
                gruAcesso = new GruposAcesso()
                {
                    emp_id = _dadosUsuarioLogado.CodigoEmpresa(),
                    gru_id = grupoId,
                    gac_visitas = 1
                };
                await _unitOfWork.GruposAcesso.AddAsync(gruAcesso);
            }
            else
            {
                gruAcesso.gac_visitas = gruAcesso.gac_visitas + 1;
                await _unitOfWork.GruposAcesso.UpsertAsync(gruAcesso);
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task<BuscarAcessosDTO> BuscarTopAcessos()
        {
            BuscarAcessosDTO buscarAcessosDTO = new BuscarAcessosDTO();
            long empId = _dadosUsuarioLogado.CodigoEmpresa();
            string sqlProd = @$"
                            select p.emp_id as EmpId, p.pro_id as ProId, p.prg_id as PrgId, p.pac_visitas as Acessos, 
                                case when p.prg_id is not null then pro.pro_descricao || '-' || prg.prg_descricao else pro.pro_descricao end as Descricao  
                            from produtosacesso p 
                            inner join produto pro on (pro.pro_id = p.pro_id)   
                            left join produtograde prg on (p.prg_id = prg.prg_id)
                            where p.emp_id = {empId}
                            order by p.pac_visitas desc
                            limit 5";

            string sqlGrupo = $@"
                            select g.emp_id as EmpId, g.gru_id  as GruId, gru.gru_nome as Descricao, g.gac_visitas as Acessos
                            from gruposacesso g 
                            inner join grupo gru on (gru.gru_id = g.gru_id)
                            where g.emp_id = {empId}
                            order by g.gac_visitas desc 
                            limit 5";
            try
            {

                var listaProd = await _unitOfWork.Context.QueryAsync<ProdutoAcessoDTO>(sqlProd);
                var listaGrup = await _unitOfWork.Context.QueryAsync<GrupoAcessoDTO>(sqlGrupo);
                buscarAcessosDTO.ListaGrupos = listaGrup.ToList();
                buscarAcessosDTO.ListaProdutos = listaProd.ToList();
                return buscarAcessosDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
