using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Pedido
    {
        public long ped_id { get; set; }
        public long loc_id { get; set; }
        public long ped_numero { get; set; }
        public long? cli_id { get; set; }
        public long? ven_id { get; set; }
        public DateTime ped_datainclusao { get; set; }
        public DateTime ped_dataprevisaoentrega { get; set; }
        public DateTime ped_datavalidade { get; set; }
        public string ped_observacao { get; set; }
        public string ped_responsavelpedido { get; set; }
        public string pes_cep { get; set; }
        public string pes_cidade { get; set; }
        public string pes_uf { get; set; }
        public string pes_bairro { get; set; }
        public string pes_nroestabelecimento { get; set; }
        public string pes_endereco { get; set; }
        public string pes_telefone { get; set; }
        public long stp_id { get; set; }
        public long? trn_id { get; set; }
        public long? trv_id { get; set; }
        public bool ped_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        public long? ped_precoutilizado { get; set; }
        public long? loc_id_transferencia { get; set; }
        public long? ope_id { get; set; }
        public int ped_modalidadefrete { get; set; }
        [JsonIgnore]
        public virtual Cliente cliente { get; set; }
        [JsonIgnore]
        public virtual Local local { get; set; }
        [JsonIgnore]
        public virtual Vendedor vendedor { get; set; }
        public virtual ICollection<PedidoItem> pedidoitens { get; set; }
    }
}
