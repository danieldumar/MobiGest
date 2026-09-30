using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/moveis")]
public class MoveisController : ControllerBase
{
    private readonly MovelService service;

    public MoveisController(MovelService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Movel>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Movel> GetPorId(int id)
    {
        Movel? movel = service.GetPorId(id);
        return movel is null ? NotFound("Móvel não encontrado") : Ok(movel);
    }

    [HttpPost]
    public ActionResult<Movel> Criar(Movel movel)
    {
        try
        {
            service.Criar(movel);
            return CreatedAtAction(nameof(GetPorId), new { id = movel.Id }, movel);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Movel> Atualizar(int id, Movel movel)
    {
        try
        {
            if (!service.Atualizar(id, movel))
            {
                return NotFound("Móvel não encontrado");
            }

            Movel movelAtualizado = service.GetPorId(id)!;
            return Ok(movelAtualizado);
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