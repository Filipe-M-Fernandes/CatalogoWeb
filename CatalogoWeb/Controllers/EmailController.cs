using CatalogoWeb.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private IEnviaEmailService _emailService;
        public EmailController(IEnviaEmailService emailService)
        {
            _emailService = emailService;
        }

        [AllowAnonymous]
        [HttpPost("Enviar")]
        public async Task<ActionResult> EnviarEmail()
        {
            try
            {
                await _emailService.EnviaEmail("filipe.fernandes@abase.com.br", "Teste", "teste 1", false);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("BuscarLogo")]
        public async Task<ActionResult<string>> BuscarLogo()
        {
            return "https://drive.google.com/uc?id=1VT4dOopp6g5evI9XvdcXBdn16RwY97lc";
        }
    }
}
