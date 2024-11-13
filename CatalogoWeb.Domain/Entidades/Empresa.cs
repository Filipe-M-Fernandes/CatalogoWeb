using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Empresa
    {
        public int emp_id { get; set; }
        public string emp_nomefantasia { get; set; }
        public string emp_razaosocial { get; set; }
        public bool emp_ativa { get; set; }
        public DateTime emp_datainclusao { get; set; }
        public DateTime? data_sincro { get; set; }
        public byte[]? emp_logo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Local> locais { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grupo> grupos { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListaPreco> listaprecos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Marca> marcas { get; set; }
        [JsonIgnore]
        public virtual ICollection<ModalidadeGrade> modalidadesgrades { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ncm> ncms { get; set; }
        //public virtual ICollection<ParametrosEmpresa> parametrosempresas { get; set; }
        // [JsonIgnore]
        //public virtual ICollection<Pessoa> pessoas { get; set; }  
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
        /*[JsonIgnore]
        public virtual ICollection<StatusPedido> statuspedidos { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioAcesso> usuarioacessos { get; set; }*/
    }
}
