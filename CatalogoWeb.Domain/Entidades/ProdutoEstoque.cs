using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ProdutoEstoque
    {
        public long pre_id { get; set; }
        public long loc_id { get; set; }
        public long? aes_id { get; set; }
        public long pro_id { get; set; }
        public long? ses_id { get; set; }
        public int pre_tiporegistro { get; set; }
        public decimal pre_qtde { get; set; }
        public decimal? pre_valorcustomedio { get; set; }
        public decimal? pre_custoultimacompra { get; set; }
        public DateTime pre_dataposicao { get; set; }
        public DateTime? data_sincro { get; set; }
        public long? prg_id { get; set; }
        [JsonIgnore]
        public virtual Local local { get; set; }
        [JsonIgnore]
        public virtual ProdutoGrade produtograde { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
    }
}
