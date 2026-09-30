using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/favoritos")]
public class FavoritosController : ControllerBase
{
    private readonly FavoritoService service;

    public FavoritosController(FavoritoService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Favorito>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Favorito> GetPorId(int id)
    {
        Favorito? favorito = service.GetPorId(id);
        return favorito is null ? NotFound("Favorito não encontrado") : Ok(favorito);
    }

    [HttpPost]
    public ActionResult<Favorito> Criar(Favorito favorito)
    {
        try
        {
            service.Criar(favorito);
            return CreatedAtAction(nameof(GetPorId), new { id = favorito.IdMovel }, favorito);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Favorito> Atualizar(int id)
    {
        try
        {
            if (!service.Atualizar(id))
            {
                return NotFound("Favorito não encontrado");
            }

            Favorito favoritoAtualizado = service.GetPorId(id)!;
            return Ok(favoritoAtualizado);
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
            : NotFound("Favorito não encontrado");
    }
}