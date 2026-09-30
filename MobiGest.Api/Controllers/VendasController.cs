using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/vendas")]
public class VendasController : ControllerBase
{
    private readonly VendaService service;

    public VendasController(VendaService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Venda>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Venda> GetPorId(int id)
    {
        Venda? venda = service.GetPorId(id);
        return venda is null ? NotFound("Venda não encontrada") : Ok(venda);
    }

    [HttpPost]
    public ActionResult<Venda> Criar(Venda venda)
    {
        try
        {
            service.Criar(venda);
            return CreatedAtAction(nameof(GetPorId), new { id = venda.Id }, venda);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Venda> Atualizar(int id, Venda venda)
    {
        try
        {
            if (!service.Atualizar(id, venda))
            {
                return NotFound("Venda não encontrada");
            }

            Venda vendaAtualizada = service.GetPorId(id)!;
            return Ok(vendaAtualizada);
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
            : NotFound("Venda não encontrada");
    }
}