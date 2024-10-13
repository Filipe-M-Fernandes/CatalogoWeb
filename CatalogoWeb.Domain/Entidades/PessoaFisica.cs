using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class PessoaFisica
    {
        public long pef_id { get; set; }
        public long pes_id { get; set; }
        public int? ecv_id { get; set; }
        public DateTime? pef_datanascimento { get; set; }
        public int? pef_codigocidadenascimento { get; set; }
        public DateTime? pef_dataalteracao { get; set; }
        public string pef_sexo { get; set; }
        public string pef_cpf { get; set; }
        public string pef_rg { get; set; }
        public string pef_rgorgaoexpedidor { get; set; }
        public DateTime? pef_rgdataexpedicao { get; set; }
        public string pef_rguf { get; set; }
        public string pef_apelido { get; set; }
        public decimal? pef_renda { get; set; }
        public bool pef_produtorrural { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
    }
}
