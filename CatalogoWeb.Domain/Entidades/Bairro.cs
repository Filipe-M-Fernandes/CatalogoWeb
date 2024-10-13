
using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Bairro
    {
        public long bai_id { get; set; }
        public string bai_nome { get; set; }
        public bool bai_ativo { get; set; }
        [JsonIgnore]
        public virtual ICollection<LogradouroCidade> logradourocidades { get; set; }
    }
}
