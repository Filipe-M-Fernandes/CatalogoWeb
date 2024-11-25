namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IImagemService
    {
        Task SalvarImagemComoBase64Async(long proId, string caminhoImagem, int largura, int altura);
    }
}
