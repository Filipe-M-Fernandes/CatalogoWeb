using CatalogoWeb.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagemProdutoController : ControllerBase
    {
        private IConfiguration _configuration;
        private IImagemService _imagemService;
        public ImagemProdutoController(IConfiguration configuration, IImagemService imagemService)
        {
            _configuration = configuration;
            _imagemService = imagemService;
        }

        [AllowAnonymous]
        [HttpGet("EnviarProduto")]
        public async Task<ActionResult> EnviarImgProduto([FromQuery] long id, [FromQuery] string caminhoImg)
        {
            try
            {
                await _imagemService.SalvarImagemComoBase64Async(id, caminhoImg, 800, 400);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
