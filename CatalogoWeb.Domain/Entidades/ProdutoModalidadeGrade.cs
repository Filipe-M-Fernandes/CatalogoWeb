using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ProdutoModalidadeGrade 
    {
        public long prg_id { get; set; }
        public long mgp_id { get; set; }

        [JsonIgnore]
        public virtual ProdutoGrade produtograde { get; set; }
        [JsonIgnore]
        public virtual ModalidadeGrade modalidadegrade { get; set; }

    }
}
