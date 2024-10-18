namespace CatalogoWeb.Domain.DTO
{
    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? CodigoEmpresa { get; set; }
        public long? CodigoLocal { get; set; }
    }
}
