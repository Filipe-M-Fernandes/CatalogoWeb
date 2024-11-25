using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ModalidadeGrade
    {
        public long mgp_id { get; set; }
        public int emp_id { get; set; }
        public long? mgp_modalidade { get; set; }
        public string mgp_descricao { get; set; }
        public bool? mgp_imprimenaetiqueta { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProdutoModalidadeGrade> produtomodalidadegrade { get; set; }
        [JsonIgnore]
        public ICollection<ModalidadeGrade> ModalidadeGradePai { get; set; }

    }
}
