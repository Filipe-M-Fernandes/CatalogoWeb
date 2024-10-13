using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Pais
    {
        public int pse_id { get; set; }
        public string pse_nome { get; set; }
        public string pse_nacionalidade { get; set; }
        public string pse_sigla { get; set; }
        public string pse_siglaiso { get; set; }
        public int pse_codigoiso { get; set; }
        public string pse_formatocep { get; set; }
        public bool pse_status { get; set; }
        public string pse_codigobacen { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual ICollection<Estado> estados { get; set; }
    }
}
