using Microsoft.AspNetCore.Mvc;
using MobiGest.Api.Models;
using MobiGest.Api.Services;

namespace MobiGest.Api.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService service;

    public UsuariosController(UsuarioService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ActionResult<List<Usuario>> GetTodos()
    {
        return Ok(service.GetTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Usuario> GetPorId(int id)
    {
        Usuario? usuario = service.GetPorId(id);
        return usuario is null ? NotFound("Usuário não encontrado") : Ok(usuario);
    }

    [HttpPost]
    public ActionResult<Usuario> Criar(Usuario usuario)
    {
        try
        {
            service.Criar(usuario);
            return CreatedAtAction(nameof(GetPorId), new { id = usuario.Id }, usuario);
        }
        catch (ArgumentException erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Usuario> Atualizar(int id, Usuario usuario)
    {
        try
        {
            if (!service.Atualizar(id, usuario))
            {
                return NotFound("Usuário não encontrado");
            }

            Usuario usuarioAtualizado = service.GetPorId(id)!;
            return Ok(usuarioAtualizado);
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
            : NotFound("Usuário não encontrado");
    }
}