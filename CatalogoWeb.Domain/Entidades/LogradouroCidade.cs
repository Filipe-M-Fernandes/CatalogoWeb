using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class LogradouroCidade
    {

        public int lcd_id { get; set; }
        public int? cep_id { get; set; }
        public int log_id { get; set; }
        public int? cid_id { get; set; }
        public long? bai_id { get; set; }
        public DateTime? data_sincro { get; set; }
        public virtual Bairro bairro { get; set; }
        public virtual Cep cep { get; set; }
        public virtual Cidade cidade { get; set; }
        public virtual Logradouro logradouro { get; set; }
        [JsonIgnore]
        public virtual ICollection<Local> locais { get; set; }
        [JsonIgnore]
        public virtual ICollection<PessoaEndereco> pessoaenderecos { get; set; }
    }
}
