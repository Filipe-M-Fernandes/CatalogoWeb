using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Cliente
    {
        public long cli_id { get; set; }
        public long pes_id { get; set; }
        public int? cbo_id { get; set; }
        public long cli_codigo { get; set; }
        public bool cli_naoprotestar { get; set; }
        public decimal? cli_valorlimitecredito { get; set; }
        public DateTime? cli_datainiciallimitecred { get; set; }
        public DateTime? cli_datafinallimitecred { get; set; }
        public string cli_observacao { get; set; }
        public int? cli_regimetributariofiscal { get; set; }
        public bool cli_ativo { get; set; }
        public DateTime cli_datainclusao { get; set; }
        public DateTime cli_dataalteracao { get; set; }
        public bool cli_vendasomenteavista { get; set; }
        public DateTime? data_sincro { get; set; }
        public bool cli_clientecontribuinteicms { get; set; }
        public long? cat_id { get; set; }
        public long? atv_id { get; set; }
        public bool cli_prospect { get; set; }
        public bool cli_calcularetencao { get; set; }
        public decimal? cli_percdescontopadrao { get; set; }

        [JsonIgnore]
        public virtual Pessoa pessoa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
