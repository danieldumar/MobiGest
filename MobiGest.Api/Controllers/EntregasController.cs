using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/entregas")]
public class EntregasController : ControllerBase
{
    private readonly EntregaService service;

    public EntregasController(EntregaService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Entrega>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Entrega> GetPorId(int id)
    {
        Entrega? entrega = service.GetPorId(id);
        return entrega is null ? NotFound("Entrega não encontrada") : Ok(entrega);
    }

    [HttpPost]
    public ActionResult<Entrega> Criar(Entrega entrega)
    {
        try
        {
            service.Criar(entrega);
            return CreatedAtAction(nameof(GetPorId), new { id = entrega.Id }, entrega);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Entrega> Atualizar(int id, Entrega entrega)
    {
        try
        {
            if (!service.Atualizar(id, entrega))
            {
                return NotFound("Entrega não encontrada");
            }

            Entrega entregaAtualizada = service.GetPorId(id)!;
            return Ok(entregaAtualizada);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Deletar(int id)
    {
        return service.Deletar(id)
            ? NoContent()
            : NotFound("Entrega não encontrada");
    }
}