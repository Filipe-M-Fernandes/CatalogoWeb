using CatalogoWeb.Api.Authorization;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalController : ControllerBase
    {
        private IDadosUsuarioLogado _dadosUsuarioLogado { get; set; }
        private ILocalService _localService { get; set; }
        private IConfiguration _configuration;


        public LocalController(IDadosUsuarioLogado dadosUsuarioLogado, ILocalService localService, IConfiguration configuration)
        {
            _dadosUsuarioLogado = dadosUsuarioLogado;
            _localService = localService;
            _configuration = configuration;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<Local>>> BuscarLista([FromQuery] int empresa)
        {
            try
            {
                FiltrosLocal filtro = new FiltrosLocal() { CodigoEmpresa = empresa, idUser = _dadosUsuarioLogado.IdUsuario() };
                return Ok(await _localService.ListarLocalUsuarioSP(filtro));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("GerarToken")]
        public async Task<ActionResult<string>> SelecionarEmpresaLocal(SelecionaEmpresaLocal empresaLocal)
        {
            try
            {
                var usuario = await _localService.SelecionarEmpresaLocal(empresaLocal);

                var tokenService = new TokenService(_configuration.GetSection("JWT"));
                string token = tokenService.GenerateToken(usuario);

                return Ok(token);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
