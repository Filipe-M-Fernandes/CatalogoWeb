using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;

namespace CatalogoWeb.Services
{
    public class ImagemService : IImagemService
    {
        private IUnitOfWork _unitOfWork;
        public ImagemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task SalvarImagemComoBase64Async(long proId, string caminhoImagem, int largura, int altura)
        {
            if (!File.Exists(caminhoImagem))
                throw new FileNotFoundException("Arquivo de imagem não encontrado.", caminhoImagem);

            using var imagemOriginal = Image.FromFile(caminhoImagem);
            using var imagemRedimensionada = new Bitmap(imagemOriginal, new Size(largura, altura));
            using var stream = new MemoryStream();

            imagemRedimensionada.Save(stream, ImageFormat.Png);

            string base64String = Convert.ToBase64String(stream.ToArray());
            ImagemProduto imp = new ImagemProduto()
            {
                pro_id = proId,
                imp_imagem = base64String
            };
            await _unitOfWork.ImagemProduto.AddAsync(imp);
        }

    }
}
