using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.DTO
{
    public class ProdutoDTO
    {

        public long pro_id { get; set; }
        public long? sgp_id { get; set; }
        public string sgp_nome { get; set; }
        public long? gru_id { get; set; }
        public string gru_nome { get; set; }
        public long? mar_id { get; set; }
        public string mar_nome { get; set; }
        public string ump_id { get; set; }
        public string ump_descricao { get; set; }
        public int ump_casasdecimais { get; set; }
        public long? ncm_id { get; set; }
        public long? pru_id { get; set; }
        public string emb_ump_id { get; set; }
        public decimal? pru_quantidade { get; set; }
        public string ncm_descricao { get; set; }
        public string ncm_codigo { get; set; }
        public long pro_codigo { get; set; }
        public string pro_ean { get; set; }
        public string pro_codigoetiqueta { get; set; }
        public string pro_descricao { get; set; }
        public string pro_referencia { get; set; }
        public bool pro_produto { get; set; }
        public bool? pro_servico { get; set; }
        public string pro_observacao { get; set; }
        public decimal dpr_precovenda { get; set; }
        public decimal? pro_pesobruto { get; set; }
        public decimal? pro_pesoliquido { get; set; }
        public long? icm_id { get; set; }
        public bool pro_ativo { get; set; }
        public string cet_id { get; set; }
        public string cet_descricao { get; set; }
        public int? cen_id { get; set; }
        public string cen_ncm { get; set; }
        public decimal? lpi_valorvenda { get; set; }
        public bool pro_usagrade { get; set; }
        public DateTime? pro_datainclusao { get; set; }
        public DateTime? data_sincro { get; set; }
        public long? pre_id { get; set; }
        public long? loc_id { get; set; }
        public decimal? pre_qtde { get; set; }
        public decimal? pre_valorcustomedio { get; set; }
        public decimal? pre_custoultimacompra { get; set; }
        public long? prg_id { get; set; }
        public string prg_ean { get; set; }
        public string prg_codigoetiqueta { get; set; }
        public decimal? prg_valorvenda { get; set; }
        public bool? prg_ativa { get; set; }

        public List<ListaPrecoItem> listaPreco { get; set; }
        public List<ProdutoEstoque> produtoEstoque { get; set; }
        public List<ProdutoGradeDTO> produtoGrade { get; set; }

        public ProdutoDTO()
        {
            this.listaPreco = new List<ListaPrecoItem>();
            this.produtoEstoque = new List<ProdutoEstoque>();
            this.produtoGrade = new List<ProdutoGradeDTO>();
        }

    }
}
