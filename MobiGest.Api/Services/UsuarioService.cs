using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class UsuarioService
{
    private readonly UsuarioRepository repository;

    public UsuarioService(UsuarioRepository repository)
    {
        this.repository = repository;    
    }

    public List<Usuario> GetTodos()
    {
        return repository.GetTodos();
    }

    public Usuario? GetPorId(int id)
    {
        Usuario? usuario = repository.GetPorId(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        return usuario;
    }

    public void Criar(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nome))
        {
            throw new Exception("O nome do usuário é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            throw new Exception("O email do usuário é obrigatório");
        }

        repository.Criar(usuario);
    }

    public bool Atualizar(int id, Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nome))
        {
            throw new Exception("O nome do usuário é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            throw new Exception("O e-mail do usuário é obrigatório");
        }

        return repository.Atualizar(id, usuario);
    }

    public bool Deletar(int id)
    {
        bool usuarioExistente = repository.Deletar(id);
        if (!usuarioExistente)
        {
            throw new Exception("Usuário não encontrado");
        }

        return true;
    }

}
