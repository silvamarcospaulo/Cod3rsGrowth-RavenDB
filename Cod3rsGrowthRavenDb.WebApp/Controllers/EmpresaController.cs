using Cod3rsGrowthRavenDb.Dominio.Filtros;
using Cod3rsGrowthRavenDb.Dominio.Modelos;
using Cod3rsGrowthRavenDb.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cod3rsGrowthRavenDb.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaServico _empresaServico;

        public EmpresaController(EmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Empresa empresa)
        {
            _empresaServico.Criar(empresa);
            return Created(empresa.Id.ToString(), empresa);
        }

        [HttpGet]
        public async Task<OkObjectResult> ObterTodos([FromQuery] EmpresaFiltro? filtro)
        {
            var empresas = await _empresaServico.ObterTodos(filtro);
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId([FromRoute] string id)
        {
            var empresa = _empresaServico.ObterPorId(id);
            return Ok(empresa);
        }

        [HttpPatch]
        public NoContentResult Atualizar([FromBody] Empresa baralho)
        {
            _empresaServico.Atualizar(baralho);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover([FromRoute] string id)
        {
            var resultado = _empresaServico.Remover(id);
            return NoContent();
        }
    }
}