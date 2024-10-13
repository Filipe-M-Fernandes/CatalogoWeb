using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PessoaJuridica
    {
        public long pej_id { get; set; }
        public long pes_id { get; set; }
        public DateTime? pej_datafundacao { get; set; }
        public string pej_cnpj { get; set; }
        public string pej_inscricaoestadual { get; set; }
        public string pej_nomefantasia { get; set; }
        public string pej_pessoacontato { get; set; }
        public string pej_emailpessoacontato { get; set; }
        public DateTime? pej_databaixasefaz { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
    }
}
