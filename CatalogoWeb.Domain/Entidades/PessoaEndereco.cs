using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PessoaEndereco
    {
        public long pee_id { get; set; }
        public int tpe_id { get; set; }
        public long pes_id { get; set; }
        public int lcd_id { get; set; }
        public string pee_complemento { get; set; }
        public string pee_localreferencia { get; set; }
        public bool pee_ativo { get; set; }
        public bool pee_enderecoprincipal { get; set; }
        public string pee_numero { get; set; }
        public DateTime? data_sincro { get; set; }
        public virtual LogradouroCidade logradourocidade { get; set; }
        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
        public virtual TipoEndereco tipoendereco { get; set; }
    }
}
