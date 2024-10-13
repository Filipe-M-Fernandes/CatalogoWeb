
using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Cep
    {
        public int cep_id { get; set; }
        public string cep_cep { get; set; }
        public int cid_id { get; set; }
        [JsonIgnore]
        public virtual Cidade cidade { get; set; }
        [JsonIgnore]
        public virtual ICollection<LogradouroCidade> logradourocidades { get; set; }
    }
}
