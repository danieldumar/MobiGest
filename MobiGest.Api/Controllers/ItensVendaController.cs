using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/itensVenda")]
public class ItensVendaController : ControllerBase
{
    private readonly ItemVendaService service;

    public ItensVendaController(ItemVendaService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<ItemVenda>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ItemVenda> GetPorId(int id)
    {
        ItemVenda? itemVenda = service.GetPorId(id);
        return itemVenda is null ? NotFound("Item de venda não encontrado") : Ok(itemVenda);
    }

    [HttpPost]
    public ActionResult<ItemVenda> Criar(ItemVenda itemVenda)
    {
        try
        {
            service.Criar(itemVenda);
            return CreatedAtAction(nameof(GetPorId), new { id = itemVenda.Id }, itemVenda);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<ItemVenda> Atualizar(int id, ItemVenda itemVenda)
    {
        try
        {
            if (!service.Atualizar(id, itemVenda))
            {
                return NotFound("Item de venda não encontrado");
            }
            ItemVenda itemVendaAtualizado = service.GetPorId(id)!;
            return Ok(itemVendaAtualizado);
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
            : NotFound("Item de venda não encontrado");
    }
}