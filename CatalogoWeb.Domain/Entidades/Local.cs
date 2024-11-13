using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Local
    {
        public long loc_id { get; set; }
        public int emp_id { get; set; }
        public string loc_codigo { get; set; }
        public string loc_descricao { get; set; }
        public string loc_cnpj { get; set; }
        public string loc_complemento { get; set; }
        public string loc_pontoreferencia { get; set; }
        public string loc_numeroestabelecimento { get; set; }
        public string loc_telefone { get; set; }
        public bool loc_ativo { get; set; }
        public string loc_cpfresponsavel { get; set; }
        public DateTime loc_datainclusao { get; set; }
        public bool loc_matriz { get; set; }
        public string loc_nomefantasia { get; set; }
        public byte[]? loc_logo { get; set; }

        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        /*public virtual LogradouroCidade logradouroCidade { get; set; }
        [JsonIgnore]
        public virtual ParametrosLocal parametrolocal { get; set; }*/
        [JsonIgnore]
        public virtual ICollection<ListaPreco> listaprecos { get; set; }
        /*[JsonIgnore]
        public virtual ICollection<Pedido> pedidos { get; set; }*/
        [JsonIgnore]
        public virtual ICollection<ProdutoEstoque> produtoestoques { get; set; }
       /* [JsonIgnore]
        public virtual ICollection<Vendedor> vendedores { get; set; }*/
        [JsonIgnore]
        public virtual ICollection<UsuariosLocais> usuarioslocais { get; set; }
    }
}
