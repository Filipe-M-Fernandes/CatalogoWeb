namespace CatalogoWeb.Domain.DTO
{
    public class ProdutoGradeDTO
    {
        public long pro_id { get; set; }
        public long? prg_id { get; set; }
        public string prg_ean { get; set; }
        public string prg_descricao { get; set; }
    }
}
