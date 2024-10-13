using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PedidoItem
    {
        public long pdi_id { get; set; }
        public long ped_id { get; set; }
        public long pro_id { get; set; }
        public decimal pdi_quantidade { get; set; }
        public decimal pdi_valorunitario { get; set; }
        public decimal pdi_valoracrescimo { get; set; }
        public decimal pdi_valordesconto { get; set; }
        public decimal pdi_valortotal { get; set; }
        public decimal pdi_basecalculoicms { get; set; }
        public decimal pdi_percentualicms { get; set; }
        public decimal pdi_valoricms { get; set; }
        public decimal pdi_basecalculoicmsst { get; set; }
        public decimal pdi_percentualicmsst { get; set; }
        public decimal pdi_valoricmsst { get; set; }
        public decimal pdi_basecalculoipi { get; set; }
        public decimal pdi_percentualipi { get; set; }
        public decimal pdi_valoripi { get; set; }
        public string pdi_ncm { get; set; }
        public decimal pdi_valorfrete { get; set; }
        public decimal pdi_valorseguro { get; set; }
        public decimal pdi_valoroutrasdespesas { get; set; }
        public string pdi_observacao { get; set; }
        public int pdi_numeroitem { get; set; }
        public DateTime? data_sincro { get; set; }
        public long? prg_id { get; set; }
        [JsonIgnore]
        public virtual Pedido pedido { get; set; }
        [JsonIgnore]
        public virtual ProdutoGrade produtograde { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
    }
}
