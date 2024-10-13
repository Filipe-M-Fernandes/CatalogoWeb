using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Estado
    {
        public int est_id { get; set; }
        public int pse_id { get; set; }
        public string est_descricao { get; set; }
        public string est_sigla { get; set; }
        public bool est_status { get; set; }
        public string est_codigocno { get; set; }
        public int? est_relacaoicms { get; set; }
        public string est_siglanfeexterior { get; set; }
        public string est_formatotelefone { get; set; }
        public DateTime? data_sincro { get; set; }
        public decimal? est_valornfcesemconsumidor { get; set; }

        public virtual Pais pais { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cidade> cidades { get; set; }
    }
}
