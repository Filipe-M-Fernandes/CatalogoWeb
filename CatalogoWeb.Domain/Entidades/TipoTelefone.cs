using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class TipoTelefone
    {
 
        public int tpt_id { get; set; }
        public string tpt_descricao { get; set; }
        public bool tpt_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual ICollection<PessoaTelefone> pessoatelefones { get; set; }
    }
}
