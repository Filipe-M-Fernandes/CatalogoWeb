﻿using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api
{

    [ApiController]
    [Route("[controller]")]
    public class UnidadeMedidaController : ControllerBase
    {
        private IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<UnidadeMedida>>> Listar()
        {
            try
            {
                return Ok(await _unidadeMedidaService.Listar());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
