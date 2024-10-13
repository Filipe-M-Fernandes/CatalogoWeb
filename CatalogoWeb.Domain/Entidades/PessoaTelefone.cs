using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PessoaTelefone
    {
        public long psc_id { get; set; }
        public long pes_id { get; set; }
        public int tpt_id { get; set; }
        public string psc_numero { get; set; }
        public string psc_ramal { get; set; }
        public bool psc_principal { get; set; }
        public string psc_observacao { get; set; }
        public bool psc_ativo { get; set; }
        public DateTime? data_sincro { get; set; }

        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
        public virtual TipoTelefone tipotelefone { get; set; }
    }
}
