using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Pessoa
    {
        public long pes_id { get; set; }
        public int emp_id { get; set; }
        public string pes_nome { get; set; }
        public int pes_fisicajuridica { get; set; }
        public DateTime pes_datainclusao { get; set; }
        public DateTime? pes_dataalteracao { get; set; }
        public bool pes_ativo { get; set; }
        public bool pes_cliente { get; set; }
        public bool pes_fornecedor { get; set; }
        public bool pes_vendedor { get; set; }
        public bool pes_transportador { get; set; }
        public bool pes_funcionario { get; set; }
        public bool pes_motorista { get; set; }
        public string pes_idestrangeiro { get; set; }
        public bool pes_orgaopublico { get; set; }
        public bool pes_contato { get; set; }
        public bool pes_parceiro { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cliente> clientes { get; set; }
        public virtual ICollection<PessoaEmail> pessoaemails { get; set; }
        public virtual ICollection<PessoaEndereco> pessoaenderecos { get; set; }
        public virtual ICollection<PessoaFisica> pessoafisicas { get; set; }
        [JsonIgnore]
        public virtual ICollection<PessoaJuridica> pessoajuridicas { get; set; }
        public virtual ICollection<PessoaTelefone> pessoatelefones { get; set; }
        [JsonIgnore]
        public virtual ICollection<Vendedor> vendedores { get; set; }
    }
}
