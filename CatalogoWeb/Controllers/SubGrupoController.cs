using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubGrupoController : ControllerBase
    {
        private ISubGrupoService _subGrupoService;

        public SubGrupoController(ISubGrupoService subGrupoService)
        {
            _subGrupoService = subGrupoService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<SubGrupo>>> Buscar([FromQuery] FiltrosSubGrupo filtros)
        {
            try
            {
                PagedParams pag = new PagedParams() { PageNumber = 1, PageSize = 200 };
                return Ok(await _subGrupoService.Listar(filtros, pag));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
