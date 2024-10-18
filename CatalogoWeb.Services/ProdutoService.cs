using AutoMapper;
using CatalogoWeb.Core;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Enuns;
using CatalogoWeb.Infrastructure;
using CatalogoWeb.Infrastructure.Data;

namespace CatalogoWeb.Services
{
    public class ProdutoService : IProdutoService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IDadosUsuarioLogado _dadosUsuarioLogado;

        public ProdutoService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        public async Task<PagedModel<ProdutoGradeDTO>> ListaProdutoComGradeFiltro(FiltrosGerais filtros, PagedParams paginacao)
        {
            var parametrosSql = new
            {
                CodigoEmpresa = _dadosUsuarioLogado.CodigoEmpresa(),
                Filtro = "%" + filtros.Filtro + "%",
                FiltroNumIlike = "%" + TextoHelper.RetornaNumero(filtros.Filtro) + "%",
                FiltroNum = TextoHelper.RetornaNumero(filtros.Filtro)
            };
            string sql = @$"select pro.pro_id, 
                        pro.pro_codigo, 
                        pro.pro_ean, 
                        pro.pro_codigoetiqueta, 
                        pro.pro_descricao, 
                        pro.pro_referencia, 
                        ncm.ncm_codigo, 
                        coalesce((select STRING_AGG(ModalidadeGrade.mgp_descricao, ' ') from produto_modalidadegrade
                        inner join ModalidadeGrade on (ModalidadeGrade.mgp_id = produto_modalidadegrade.mgp_id)    
                        where (produto_modalidadegrade.prg_id = prg.prg_id)), '') as grade,
                        prg.prg_id,
                        prg.prg_ean
                        from Produto pro
                        left join ProdutoGrade prg on(pro.pro_id = prg.pro_id)
                        LEFT JOIN ncm ON(pro.ncm_id = ncm.ncm_id)
                        where pro.emp_id = @CodigoEmpresa
                        AND ((pro.pro_usagrade = false 
                        AND NOT EXISTS(SELECT ProdutoGrade.pro_id FROM ProdutoGrade WHERE ProdutoGrade.pro_id = pro.pro_id)) 
                        OR (pro.pro_usagrade = true AND EXISTS(SELECT ProdutoGrade.pro_id FROM ProdutoGrade WHERE ProdutoGrade.pro_id = pro.pro_id)))";
            if (!string.IsNullOrEmpty(filtros.Filtro))
            {
                sql += " AND (pro.pro_descricao ilike @Filtro OR pro.pro_modelo ilike @Filtro OR pro.pro_codigoetiqueta ilike @Filtro OR pro.pro_referencia ilike @Filtro OR prg.prg_codigoetiqueta ilike @Filtro ";
                if (!string.IsNullOrEmpty(TextoHelper.RetornaNumeros(filtros.Filtro)) && TextoHelper.RetornaLetras(filtros.Filtro).Length == 0)
                {
                    sql += @" OR pro.pro_codigo = @FiltroNum";
                    if (TextoHelper.RetornaNumeros(filtros.Filtro).Length > 4)
                        sql += @" OR pro.pro_ean ilike @FiltroNumIlike OR prg.prg_ean ilike @FiltroNumIlike ";
                }
                sql += ")";
            }
            string sqlCount = TotalListaProdutoComGradeFiltro(filtros);
            return await _unitOfWork.Context.QueryAsyncPaged<ProdutoGradeDTO>(sql, sqlCount, paginacao, parametrosSql);
        }

        private string TotalListaProdutoComGradeFiltro(FiltrosGerais filtros)
        {
            var parametrosSql = new
            {
                CodigoEmpresa = _dadosUsuarioLogado.CodigoEmpresa(),
                Filtro = "%" + filtros.Filtro + "%",
                FiltroNumIlike = "%" + TextoHelper.RetornaNumero(filtros.Filtro) + "%",
                FiltroNum = TextoHelper.RetornaNumero(filtros.Filtro)
            };
            string sql = @$"select pro.pro_id, 
                        pro.pro_codigo, 
                        pro.pro_ean, 
                        pro.pro_codigoetiqueta, 
                        pro.pro_descricao, 
                        pro.pro_referencia, 
                        ncm.ncm_codigo, 
                        coalesce((select STRING_AGG(ModalidadeGrade.mgp_descricao, ' ') from produto_modalidadegrade
                        inner join ModalidadeGrade on (ModalidadeGrade.mgp_id = produto_modalidadegrade.mgp_id)    
                        where (produto_modalidadegrade.prg_id = prg.prg_id)), '') as grade,
                        prg.prg_id 
                        from Produto pro
                        left join ProdutoGrade prg on(pro.pro_id = prg.pro_id)
                        LEFT JOIN ncm ON(pro.ncm_id = ncm.ncm_id)
                        where pro.emp_id = @CodigoEmpresa
                        AND ((pro.pro_usagrade = false 
                        AND NOT EXISTS(SELECT ProdutoGrade.pro_id FROM ProdutoGrade WHERE ProdutoGrade.pro_id = pro.pro_id)) 
                        OR (pro.pro_usagrade = true AND EXISTS(SELECT ProdutoGrade.pro_id FROM ProdutoGrade WHERE ProdutoGrade.pro_id = pro.pro_id)))";
            if (!string.IsNullOrEmpty(filtros.Filtro))
            {
                sql += " AND (pro.pro_descricao ilike @Filtro OR pro.pro_modelo ilike @Filtro OR pro.pro_codigoetiqueta ilike @Filtro OR pro.pro_referencia ilike @Filtro OR prg.prg_codigoetiqueta ilike @Filtro ";
                if (!string.IsNullOrEmpty(TextoHelper.RetornaNumeros(filtros.Filtro)) && TextoHelper.RetornaLetras(filtros.Filtro).Length == 0)
                {
                    sql += @" OR pro.pro_codigo = @FiltroNum";
                    if (TextoHelper.RetornaNumeros(filtros.Filtro).Length > 4)
                        sql += @" OR pro.pro_ean ilike @FiltroNumIlike OR prg.prg_ean ilike @FiltroNumIlike ";
                }
                sql += ")";
            }
            return sql;
        }

        public async Task<PagedModel<ProdutoDTO>> ListarTodas(FiltrosProdutoListarTodos filtros, PagedParams paginacao)
        {
            var _codigoListaPreco = await BuscaTabelaPrecoPadrao();

            var parametrosSql = new
            {
                CodigoEmpresa = _dadosUsuarioLogado.CodigoEmpresa(),
                Filtro = "%" + filtros.Filtro + "%",
                FiltroNumIlike = "%" + TextoHelper.RetornaNumero(filtros.Filtro) + "%",
                FiltroNum = TextoHelper.RetornaNumero(filtros.Filtro),
                IdProduto = filtros.IdProduto,
                marca = filtros.IdMarca,
                grupo = filtros.IdGrupo,
                SubGrupo = filtros.IdSubGrupo,
                precoMinimo = filtros.PrecoMinimo,
                precoMaximo = filtros.PrecoMaximo,
                produtoAtivo = filtros.Ativo,
                filtroAdicional = filtros.FiltroAdicional,
                CodigoListaPreco = _codigoListaPreco,
            };

            string sql = $@"with cte_produtopreco as (
                        select pro.pro_id, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMinimo, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMaximo
                        from ListaPrecoItem as lpi 
                        inner join Produto pro on (lpi.pro_id = pro.pro_id)
                        inner join ListaPreco as lpc ON(lpc.emp_id = pro.emp_id and lpi.ltp_id = @CodigoListaPreco) --lpi.ltp_id AND lpc.ltp_principal = true and lpc.ltp_ativa = true)
                        WHERE pro.emp_id =   @CodigoEmpresa  and pro.pro_usagrade = false ";
            if (filtros.PrecoMinimo >= 0 && filtros.PrecoMinimo != null)
            {
                sql += "and lpi_valorvenda >= (  @precoMinimo )::decimal ";
            }
            if (filtros.PrecoMaximo > 0 && filtros.PrecoMaximo != null)
            {
                sql += "and lpi_valorvenda <= (  @precoMaximo )::decimal ";
            }
            sql += @"  group by pro.pro_id
                        ), 
                        cte_produtoprecograde as (
                        select pro.pro_id, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMinimo, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMaximo
                        from ListaPrecoItem lpi
                        inner join Produto pro on (lpi.pro_id = pro.pro_id)
                        inner join ListaPreco lpc ON(lpc.emp_id = pro.emp_id and lpi.ltp_id = @CodigoListaPreco) -- lpi.ltp_id AND lpc.ltp_principal = true and lpc.ltp_ativa = true)
                        WHERE pro.emp_id = @CodigoEmpresa  and pro.pro_usagrade = true and lpi.prg_id is not null ";
            if (filtros.PrecoMinimo >= 0 && filtros.PrecoMinimo != null)
            {
                sql += "and lpi_valorvenda >= (  @precoMinimo )::decimal ";
            }
            if (filtros.PrecoMaximo > 0 && filtros.PrecoMaximo != null)
            {
                sql += "and lpi_valorvenda <= (  @precoMaximo )::decimal ";
            }
            sql += @"  group by pro.pro_id
                        ),
                        produtos as (
                        SELECT DISTINCT pro.pro_id, pro.pro_descricao, pro.pro_datainclusao, sgp.sgp_id, sgp.sgp_nome, grp.gru_id, grp.gru_nome, 
                        mar.mar_id, mar.mar_nome, ncm.ncm_id, ncm.ncm_descricao, ncm.ncm_codigo, ncm.cip_saida, ump.ump_id, ump.ump_descricao,
                        ump.ump_casasdecimais, pro.pro_codigo, pro.pro_ean, pro.pro_codigoetiqueta, pro.pro_referencia, pro.pro_modelo,
                        pro.pro_referencia, pro.pro_modelo, pro.pro_produto, pro.pro_servico, pro.pro_materiaprima, pro.pro_usabalanca, 
                        pro.pro_ativo, pro.pro_kitcomposicao, pro.pro_observacao, pro.pro_fci, pro.cen_id,pro.pro_pesoliquido,pro.pro_pesobruto,
                        pro.pro_controlelote, pro.pro_usagrade,
                        (case when pro.pro_usagrade = true then pg.PrecoVendaMinimo else pp.PrecoVendaMinimo end) as PrecoVendaMinimo,
                        (case when pro.pro_usagrade = true then pg.PrecoVendaMaximo else pp.PrecoVendaMaximo end) as PrecoVendaMaximo
                        FROM produto pro
                        left join cte_produtopreco pp on (pp.pro_id = pro.pro_id)
                        left join cte_produtoprecograde pg on (pg.pro_id = pro.pro_id)
                        LEFT JOIN subgrupo sgp ON(pro.sgp_id = sgp.sgp_id)
                        LEFT JOIN marca mar ON (pro.mar_id = mar.mar_id)
                        LEFT JOIN ncm ON(pro.ncm_id = ncm.ncm_id)
                        LEFT JOIN unidademedida ump ON(pro.ump_id = ump.ump_id)
                        LEFT JOIN grupo grp ON(grp.gru_id = pro.gru_id)
                        LEFT JOIN produtograde prg ON(prg.pro_id = pro.pro_id)
                        WHERE pro.emp_id =   @CodigoEmpresa ";
            if (!string.IsNullOrEmpty(filtros.Filtro))
            {
                sql += " AND (pro.pro_descricao ilike @Filtro OR pro.pro_modelo ilike @Filtro OR pro.pro_codigoetiqueta ilike @Filtro OR pro.pro_referencia ilike @Filtro OR prg.prg_codigoetiqueta ilike @Filtro ";
                if (!string.IsNullOrEmpty(TextoHelper.RetornaNumeros(filtros.Filtro)) && TextoHelper.RetornaLetras(filtros.Filtro).Length == 0)
                {
                    sql += @" OR pro.pro_codigo = @FiltroNum";
                    if (TextoHelper.RetornaNumeros(filtros.Filtro).Length > 4)
                        sql += @" OR pro.pro_ean ilike @FiltroNumIlike OR prg.prg_ean ilike @FiltroNumIlike ";
                }
                sql += ")";
            }
            if (filtros.IdProduto.HasValue)
            {
                sql += " and pro.pro_id = @IdProduto ";
            }
            if (filtros.IdMarca > 0 && filtros.IdMarca != null)
            {
                sql += " and pro.mar_id = @marca ";
            }
            if (filtros.IdGrupo > 0 && filtros.IdGrupo != null)
            {
                sql += " and pro.gru_id = @grupo ";
            }
            if (filtros.IdSubGrupo > 0 && filtros.IdSubGrupo != null)
            {
                sql += " and pro.sgp_id = @SubGrupo ";
            }
            /*if (!string.IsNullOrEmpty(filtros.FiltroAdicional))
            {
                FuncaoCampoPersonalizadoService funcaoCampopersonalizado = new FuncaoCampoPersonalizadoService();
                sql += funcaoCampopersonalizado.MontarCondicaoCamposPersonalizados(filtros.FiltroAdicional);
            }*/
            if (filtros.Ativo == AtivoInativo.Ativo)
            {
                sql += " and pro.pro_ativo = true";
            }
            else if (filtros.Ativo == AtivoInativo.Inativo)
            {
                sql += " and pro.pro_ativo = false";
            }

            sql += ")";
            sql += @" select *
                        from produtos pro
                        where pro.PrecoVendaMinimo is not null and pro.PrecoVendaMaximo is not null
                        ";

            string sqlCount = TotalListarTodas(filtros, _codigoListaPreco.Value);
            return await _unitOfWork.Context.QueryAsyncPaged<ProdutoDTO>(sql, sqlCount, paginacao, parametrosSql);
        }
        public async Task<ProdutoDTO> RetornaDadosProduto(long ProdutoId)
        {
            var _codigoListaPreco = await BuscaTabelaPrecoPadrao();
            var parametrosSql = new
            {
                CodigoEmpresa = _dadosUsuarioLogado.CodigoEmpresa(),
                ProdutoId = ProdutoId,

                CodigoListaPreco = _codigoListaPreco,
            };

            string sql = @$" SELECT produto.*, subgrupo.sgp_id, subgrupo.sgp_nome, grupo.gru_id, grupo.gru_nome, marca.mar_id, marca.mar_nome, ncm.ncm_id, ncm.ncm_descricao,
                                ncm.ncm_ativo, ncm.ncm_codigo, ncm.cip_saida, tipoprodutosped.tpi_id, tipoprodutosped.tpi_descricao,
                                unidademedida.ump_id, unidademedida.ump_descricao, unidademedida.ump_casasdecimais, ListaPrecoItem.lpi_valorvenda,
                                produtounidade.pru_id,produtounidade.pru_quantidade,
                                produtounidade.ump_id as emb_ump_id
                                FROM produto
                                LEFT JOIN subgrupo ON(produto.sgp_id = subgrupo.sgp_id)
                                LEFT JOIN marca ON (produto.mar_id = marca.mar_id)
                                LEFT JOIN tributacaopiscofins ON(produto.pis_id = tributacaopiscofins.pis_id) 
                                LEFT JOIN ncm ON(produto.ncm_id = ncm.ncm_id)
                                LEFT JOIN tipoprodutosped ON(produto.tpi_id = tipoprodutosped.tpi_id)
                                LEFT JOIN unidademedida ON(produto.ump_id = unidademedida.ump_id)
                                LEFT JOIN grupo ON(grupo.gru_id = produto.gru_id)
                                LEFT JOIN produtounidade ON(produtounidade.pro_id = produto.pro_id)
                                inner JOIN ListaPrecoItem ON(ListaPrecoItem.pro_id = produto.pro_id AND ListaPrecoItem.ltp_id = @CodigoListaPreco) 
                                WHERE produto.emp_id = @CodigoEmpresa and produto.pro_id = @ProdutoId ";

            return await _unitOfWork.Context.QueryFirstAsync<ProdutoDTO>(sql, parametrosSql);

        }

        private async Task<long?> BuscaTabelaPrecoPadrao()
        {
            var _listaPreco = await _unitOfWork.ListaPreco.FindAsync(l => l.emp_id == _dadosUsuarioLogado.CodigoEmpresa() && l.ltp_principal == true && l.ltp_ativa == true);
            long? _codigoListaPreco = null;
            if (_listaPreco.Any())
            {
                _codigoListaPreco = _listaPreco.Where(l => l.loc_id == _dadosUsuarioLogado.CodigoLocal()).DefaultIfEmpty(null).FirstOrDefault()?.ltp_id;
                if (_codigoListaPreco == null)
                    _codigoListaPreco = _listaPreco.Where(l => l.loc_id == null).DefaultIfEmpty(null).FirstOrDefault()?.ltp_id;
            }
            if (_codigoListaPreco == null) throw new ArgumentException("Lista de preço não encontrada para o local!");

            return _codigoListaPreco;
        }

        private string TotalListarTodas(FiltrosProdutoListarTodos filtros, long _codigoListaPreco)
        {
            var parametrosSql = new
            {
                CodigoEmpresa = _dadosUsuarioLogado.CodigoEmpresa(),
                Filtro = "%" + filtros.Filtro + "%",
                FiltroNumIlike = "%" + TextoHelper.RetornaNumero(filtros.Filtro) + "%",
                FiltroNum = TextoHelper.RetornaNumero(filtros.Filtro),
                marca = filtros.IdMarca,
                IdProduto = filtros.IdProduto,
                grupo = filtros.IdGrupo,
                SubGrupo = filtros.IdSubGrupo,
                precoMinimo = filtros.PrecoMinimo,
                precoMaximo = filtros.PrecoMaximo,
                produtoAtivo = filtros.Ativo,
                filtroAdicional = filtros.FiltroAdicional,
                CodigoListaPreco = _codigoListaPreco,
            };

            string sql = $@" with cte_produtopreco as (
                        select pro.pro_id, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMinimo, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMaximo
                        from ListaPrecoItem as lpi 
                        inner join Produto pro on (lpi.pro_id = pro.pro_id)
                        inner join ListaPreco as lpc ON(lpc.emp_id = pro.emp_id and lpi.ltp_id = @CodigoListaPreco) --lpi.ltp_id AND lpc.ltp_principal = true and lpc.ltp_ativa = true)
                        WHERE pro.emp_id =   @CodigoEmpresa  and pro.pro_usagrade = false ";
            if (filtros.PrecoMinimo >= 0 && filtros.PrecoMinimo != null)
            {
                sql += " and lpi_valorvenda >= (  @precoMinimo )::decimal ";
            }
            if (filtros.PrecoMinimo > 0 && filtros.PrecoMaximo != null)
            {
                sql += " and lpi_valorvenda <= (  @precoMaximo )::decimal ";
            }
            sql += @"  group by pro.pro_id
                        ), 
                        cte_produtoprecograde as (
                        select pro.pro_id, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMinimo, max(coalesce(lpi_valorvenda,0)) as PrecoVendaMaximo
                        from ListaPrecoItem lpi
                        inner join Produto pro on (lpi.pro_id = pro.pro_id)
                        inner join ListaPreco as lpc ON(lpc.emp_id = pro.emp_id and lpi.ltp_id = @CodigoListaPreco) --lpi.ltp_id AND lpc.ltp_principal = true and lpc.ltp_ativa = true)
                        WHERE pro.emp_id =   @CodigoEmpresa  and pro.pro_usagrade = true and lpi.prg_id is not null ";
            if (filtros.PrecoMinimo > 0 && filtros.PrecoMinimo != null)
            {
                sql += " and lpi_valorvenda >= (  @precoMinimo )::decimal ";
            }
            if (filtros.PrecoMaximo > 0 && filtros.PrecoMaximo != null)
            {
                sql += " and lpi_valorvenda <= (  @precoMaximo )::decimal ";
            }
            sql += @"  group by pro.pro_id
                        ),
                        valor as (
                        SELECT DISTINCT pro.pro_id, pro.pro_descricao, pro.pro_datainclusao, sgp.sgp_id, sgp.sgp_nome, grp.gru_id, grp.gru_nome, 
                        mar.mar_id, mar.mar_nome, pis.pis_id,pis.pis_descricao, ncm.ncm_id, ncm.ncm_descricao, ncm.ncm_codigo, ncm.cip_saida, 
                        tpi.tpi_id, tpi.tpi_descricao,ump.ump_id, ump.ump_descricao, ump.ump_casasdecimais, csv1.csv_id, csv1.csv_descricao,
                        com.orm_id, com.orm_descricao, nat.nat_id, nat.nat_descricao, pro.pro_codigo, pro.pro_ean, pro.pro_codigoetiqueta,
                        pro.pro_referencia, pro.pro_modelo,
                        pro.pro_ativo,pro.pro_observacao, pro.pro_pesoliquido,pro.pro_pesobruto,
                        (case when pro.pro_usagrade = true then pg.PrecoVendaMinimo else pp.PrecoVendaMinimo end) as PrecoVendaMinimo,
                        (case when pro.pro_usagrade = true then pg.PrecoVendaMaximo else pp.PrecoVendaMaximo end) as PrecoVendaMaximo
                        FROM produto pro
                        left join cte_produtopreco pp on (pp.pro_id = pro.pro_id)
                        left join cte_produtoprecograde pg on (pg.pro_id = pro.pro_id)
                        LEFT JOIN subgrupo sgp ON(pro.sgp_id = sgp.sgp_id)
                        LEFT JOIN marca mar ON (pro.mar_id = mar.mar_id)
                        LEFT JOIN ncm ON(pro.ncm_id = ncm.ncm_id)
                        LEFT JOIN unidademedida ump ON(pro.ump_id = ump.ump_id)
                        LEFT JOIN grupo grp ON(grp.gru_id = pro.gru_id)
                        LEFT JOIN produtograde prg ON(prg.pro_id = pro.pro_id)
                        WHERE pro.emp_id = @CodigoEmpresa ";
            if (!string.IsNullOrEmpty(filtros.Filtro))
            {
                sql += " AND (pro.pro_descricao ilike @Filtro OR pro.pro_modelo ilike @Filtro OR pro.pro_codigoetiqueta ilike @Filtro OR pro.pro_referencia ilike @Filtro OR prg.prg_codigoetiqueta ilike @Filtro ";
                if (!string.IsNullOrEmpty(TextoHelper.RetornaNumeros(filtros.Filtro)) && TextoHelper.RetornaLetras(filtros.Filtro).Length == 0)
                {
                    sql += @" OR pro.pro_codigo = @FiltroNum";
                    if (TextoHelper.RetornaNumeros(filtros.Filtro).Length > 4)
                        sql += @" OR pro.pro_ean ilike @FiltroNumIlike OR prg.prg_ean ilike @FiltroNumIlike ";
                }
                sql += ")";
            }
            if (filtros.IdProduto.HasValue)
            {
                sql += " and pro.pro_id = @IdProduto ";
            }
            if (filtros.IdMarca > 0 && filtros.IdMarca != null)
            {
                sql += " and pro.mar_id = @marca ";
            }
            if (filtros.IdGrupo > 0 && filtros.IdGrupo != null)
            {
                sql += " and pro.gru_id = @grupo ";
            }
            if (filtros.IdSubGrupo > 0 && filtros.IdSubGrupo != null)
            {
                sql += " and pro.sgp_id = @SubGrupo ";
            }
            /*if (!string.IsNullOrEmpty(filtros.FiltroAdicional))
            {
                FuncaoCampoPersonalizadoService funcaoCampopersonalizado = new FuncaoCampoPersonalizadoService();
                sql += funcaoCampopersonalizado.MontarCondicaoCamposPersonalizados(filtros.FiltroAdicional);
            }*/
            if (filtros.Ativo == AtivoInativo.Ativo)
            {
                sql += " and pro.pro_ativo = true";
            }
            else if (filtros.Ativo == AtivoInativo.Inativo)
            {
                sql += " and pro.pro_ativo = false";
            }
            sql += ")";
            sql += $@" select count(*)as total
                        from valor pro
                        where pro.PrecoVendaMinimo is not null and pro.PrecoVendaMaximo is not null
                        ";
            return sql;
        }
    }
}
