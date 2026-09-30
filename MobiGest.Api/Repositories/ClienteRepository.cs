using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class ClienteRepository
{
    private List<Cliente> clientes = new();
    private int proximoId = 1;

    public List<Cliente> GetTodos()
    {
        return clientes;
    }

    public Cliente? GetPorId(int id)
    {
        return clientes.FirstOrDefault(cliente => cliente.Id == id);
    }

    public void Criar(Cliente cliente)
    {
        cliente.Id = proximoId++;
        clientes.Add(cliente);
    }

    public bool Atualizar(int id, Cliente cliente)
    {
        Cliente? clienteExistente = GetPorId(id); 
        if (clienteExistente == null)
        {
            return false;
        }       

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Endereco = cliente.Endereco;
        clienteExistente.Telefone = cliente.Telefone;
        clienteExistente.Comentario = cliente.Comentario;
        return true;
    }

    public bool Deletar(int id)
    {
        Cliente? clienteExistente = GetPorId(id);

        if (clienteExistente == null)
        {
            return false;
        }

        clientes.Remove(clienteExistente);
        return true;    
    }

}