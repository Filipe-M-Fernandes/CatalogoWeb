namespace CatalogoWeb.Domain.DTO
{
    public class ProdutoGradeDTO
    {
        public long pro_id { get; set; }
        public long pro_codigo { get; set; }
        public string pro_ean { get; set; }
        public string pro_descricao { get; set; }
        public string pro_referencia { get; set; }
        public string ncm_codigo { get; set; }
        public string grade { get; set; }
        public long? prg_id { get; set; }
        public string prg_ean { get; set; }
    }
}
