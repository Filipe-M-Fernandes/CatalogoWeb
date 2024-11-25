using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : ControllerBase
    {
        private IGrupoService _grupoService;

        public GrupoController(IGrupoService grupoService)
        {
            _grupoService = grupoService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<Grupo>>> Buscar([FromQuery] FiltrosGrupoProduto filtros)
        {
            try
            {
                PagedParams pag = new PagedParams() { PageNumber = 1, PageSize = 200 };
                return Ok(await _grupoService.Buscar(filtros, pag));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
