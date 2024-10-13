using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class TipoEndereco
    {

        public int tpe_id { get; set; }
        public string tpe_descricao { get; set; }
        public bool tpe_ativo { get; set; }
        public string tpe_icone { get; set; }
        public string tpe_iconecor { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual ICollection<PessoaEndereco> pessoaenderecos { get; set; }
    }
}
