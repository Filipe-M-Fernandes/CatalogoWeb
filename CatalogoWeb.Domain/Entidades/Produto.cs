using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Produto
    {
        public long pro_id { get; set; }
        public int emp_id { get; set; }
        public long? sgp_id { get; set; }
        public long? gru_id { get; set; }
        public long? mar_id { get; set; }
        public string ump_id { get; set; }
        public long? ncm_id { get; set; }
        public string pro_codigo { get; set; }
        public string pro_ean { get; set; }
        public string pro_codigoetiqueta { get; set; }
        public string pro_descricao { get; set; }
        public string pro_referencia { get; set; }
        public string pro_modelo { get; set; }
        public bool pro_produto { get; set; }
        public bool pro_ativo { get; set; }
        public string pro_observacao { get; set; }
        public int? cen_id { get; set; }
        public DateTime? data_sincro { get; set; }
        public bool pro_usagrade { get; set; }
        public DateTime? pro_datainclusao { get; set; }
        public decimal? pro_pesobruto { get; set; }
        public decimal? pro_pesoliquido { get; set; }
        public virtual Empresa empresa { get; set; }
        public virtual Grupo grupo { get; set; }
        public virtual Marca marca { get; set; }
        public virtual Ncm ncm { get; set; }
        public virtual SubGrupo subgrupo { get; set; }
        public virtual UnidadeMedida unidademedida { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListaPrecoItem> listaprecoitens { get; set; }
        public virtual ICollection<ProdutoEstoque> produtoestoques { get; set; }
        public virtual ICollection<ProdutoGrade> produtogrades { get; set; }
        public virtual ICollection<ProdutoUnidade> produtounidades { get; set; }
    }
}
