using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Ncm
    {
        public long ncm_id { get; set; }
        public string cip_entrada { get; set; }
        public string cip_saida { get; set; }
        public int emp_id { get; set; }
        public string ncm_codigo { get; set; }
        public string ncm_extipi { get; set; }
        public string ncm_descricao { get; set; }
        public decimal? ncm_percentual { get; set; }
        public DateTime? data_sincro { get; set; }
        public bool ncm_ativo { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
