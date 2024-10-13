using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PessoaEmail
    {
        public long pem_id { get; set; }
        public long pes_id { get; set; }
        public string pem_email { get; set; }
        public bool pem_emailprincipal { get; set; }
        public bool pem_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
    }
}
