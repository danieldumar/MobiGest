using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class UsuarioRepository
{
    private List<Usuario> usuarios = new List<Usuario>();
    private int proximoId = 1;

    public List<Usuario> GetTodos()
    {
        return usuarios;
    }

    public Usuario? GetPorId(int id)
    {
        return usuarios.FirstOrDefault(Usuario => Usuario.Id == id);
    }

    public void Criar(Usuario usuario)
    {
        usuario.Id = proximoId++;
        usuarios.Add(usuario);
    }

    public bool Atualizar(int id, Usuario usuario)
    {
        Usuario? usuarioExistente = GetPorId(id); 
        if (usuarioExistente == null)
        {
            return false;
        }       

        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Tipo = usuario.Tipo;
        return true;
    }

    public bool Deletar(int id)
    {
        Usuario? usuarioExistente = GetPorId(id);

        if (usuarioExistente == null)
        {
            return false;
        }

        usuarios.Remove(usuarioExistente);
        return true;    
    }

}


