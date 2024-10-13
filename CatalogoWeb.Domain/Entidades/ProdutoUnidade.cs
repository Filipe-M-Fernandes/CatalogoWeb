using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ProdutoUnidade
    {
        public long pru_id { get; set; }
        public long pro_id { get; set; }
        public string ump_id { get; set; }
        public decimal pru_quantidade { get; set; }
        public decimal pru_qtdeunidadepadrao { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
        [JsonIgnore]
        public virtual UnidadeMedida unidademedida { get; set; }
    }
}
