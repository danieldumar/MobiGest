using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService service;

    public ClientesController(ClienteService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Cliente> GetPorId(int id)
    {
        Cliente? cliente = service.GetPorId(id);
        return cliente is null ? NotFound("Cliente não encontrado") : Ok(cliente);
    }

    [HttpPost]
    public ActionResult<Cliente> Criar(Cliente cliente)
    {
        try
        {
            service.Criar(cliente);
            return CreatedAtAction(nameof(GetPorId), new { id = cliente.Id }, cliente);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Cliente> Atualizar(int id, Cliente cliente)
    {
        try
        {
            if (!service.Atualizar(id, cliente))
            {
                return NotFound("Cliente não encontrado");
            }

            Cliente clienteAtualizado = service.GetPorId(id)!;
            return Ok(clienteAtualizado);
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
            : NotFound("Móvel não encontrado");
    }
}