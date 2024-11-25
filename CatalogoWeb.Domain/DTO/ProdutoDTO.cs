using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.DTO
{
    public class ProdutoDTO
    {

        public long pro_id { get; set; }
        public string sgp_nome { get; set; }
        public string gru_nome { get; set; }
        public string mar_nome { get; set; }
        public string ump_id { get; set; }
        public string ump_descricao { get; set; }
        public decimal? pru_quantidade { get; set; }
        public string pro_codigo { get; set; }
        public string pro_ean { get; set; }
        public string pro_descricao { get; set; }
        public string pro_referencia { get; set; }
        public string pro_descricaodetalhada { get; set; }
        public string pro_descricaoresumida { get; set; }
        public string pro_observacao { get; set; }
        public decimal? valorPromocao { get; set; }
        public decimal? pro_pesobruto { get; set; }
        public decimal? pro_pesoliquido { get; set; }
        public bool pro_ativo { get; set; }
        public decimal? valorvenda { get; set; }
        public bool pro_usagrade { get; set; }
        public DateTime? pro_datainclusao { get; set; }
        public string? imagem { get; set; }
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
