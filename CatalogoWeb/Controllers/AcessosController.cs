using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessosController : ControllerBase
    {
        private IAcessosService _acessosService;
        public AcessosController(IAcessosService acessosService)
        {
            _acessosService = acessosService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<BuscarAcessosDTO>> BuscarAcessos()
        {
            try
            {
                var ret = await _acessosService.BuscarTopAcessos();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AcessoProduto")]
        public async Task<ActionResult<bool>> EnviarAcessoProduto([FromQuery] long ProId, [FromQuery] long? PrgId)
        {
            try
            {

                await _acessosService.AcessoProduto(ProId, PrgId);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("AcessoGrupo")]
        public async Task<ActionResult<bool>> EnviarAcessosGrupo(long grupoId)
        {
            try
            {
                await _acessosService.AcessoGrupo(grupoId);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
