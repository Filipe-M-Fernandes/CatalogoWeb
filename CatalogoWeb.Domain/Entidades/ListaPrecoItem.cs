using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ListaPrecoItem
    {
        public long lpi_id { get; set; }
        public long ltp_id { get; set; }
        public long pro_id { get; set; }
        public decimal lpi_valorvenda { get; set; }
        public long? prg_id { get; set; }
        public virtual ListaPreco listapreco { get; set; }
        [JsonIgnore]
        public virtual ProdutoGrade produtograde { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
    }
}
