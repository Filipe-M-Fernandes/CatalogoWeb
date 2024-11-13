using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private IDadosUsuarioLogado _dadosUsuarioLogado;
        private IEmpresaService _empresaService;

        public EmpresaController(IDadosUsuarioLogado dadosUsuarioLogado, IEmpresaService empresaService)
        {
            _dadosUsuarioLogado = dadosUsuarioLogado;
            _empresaService = empresaService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<Empresa>>> BuscarTodas()
        {
            try
            {
                long userID = _dadosUsuarioLogado.IdUsuario();
                return Ok(await _empresaService.ListarEmpresasUsuario(userID));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
