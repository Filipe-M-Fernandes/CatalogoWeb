using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Logradouro
    {
        public int log_id { get; set; }
        public string log_logradouro { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual ICollection<LogradouroCidade> logradourocidades { get; set; }
    }
}
