using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class ClienteService
{
    private readonly ClienteRepository repository;

    public ClienteService(ClienteRepository repository)
    {
        this.repository = repository;    
    }

    public List<Cliente> GetTodos()
    {
        return repository.GetTodos();
    }

    public Cliente? GetPorId(int id)
    {
        return repository.GetPorId(id);
    }

    public void Criar(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new Exception("O nome do cliente é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(cliente.Endereco))
        {
            throw new Exception("O endereço do cliente é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(cliente.Telefone))
        {
            throw new Exception("O telefone do cliente é obrigatório");
        }

        repository.Criar(cliente);
    }

    public bool Atualizar(int id, Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new Exception("O nome do cliente é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(cliente.Endereco))
        {
            throw new Exception("O endereço do cliente é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(cliente.Telefone))
        {
            throw new Exception("O telefone do cliente é obrigatório");
        }

        return repository.Atualizar(id, cliente);
    }

    public bool Deletar(int id)
    {
        return repository.Deletar(id);
    }

}