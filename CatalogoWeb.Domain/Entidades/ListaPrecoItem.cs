using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ListaPrecoItem
    {
        public long lpi_id { get; set; }
        public long ltp_id { get; set; }
        public long pro_id { get; set; }
        public decimal lpi_valorvenda { get; set; }
        public decimal? lpi_perccomissao { get; set; }
        public bool lpi_naocalculacomissao { get; set; }
        public DateTime? data_sincro { get; set; }
        public long? prg_id { get; set; }
        public decimal? lpi_valorvendaanterior { get; set; }
        [JsonIgnore]
        public virtual ListaPreco listapreco { get; set; }
        [JsonIgnore]
        public virtual ProdutoGrade produtograde { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
    }
}
