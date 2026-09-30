using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class EntregaService
{
    private readonly EntregaRepository repository;

    public EntregaService(EntregaRepository repository)
    {
        this.repository = repository;    
    }

    public List<Entrega> GetTodos()
    {
        return repository.GetTodos();
    }

    public Entrega? GetPorId(int id)
    {
        Entrega? entrega = repository.GetPorId(id);
        if (entrega == null)
        {
            throw new Exception("Entrega não encontrada");
        }
        return entrega;
    }

    public void Criar(Entrega entrega)
    {
        if (string.IsNullOrWhiteSpace(entrega.Endereco))
        {
            throw new Exception("O endereço da entrega é obrigatório");
        }   

        if (string.IsNullOrWhiteSpace(entrega.Data.ToString()))
        {
            throw new Exception("A data da entrega é obrigatória");
        }

        repository.Criar(entrega);
    }

    public bool Atualizar(int id, Entrega entrega)
    {
        if (string.IsNullOrWhiteSpace(entrega.Endereco))
        {
            throw new Exception("O endereço da entrega é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(entrega.Data.ToString()))
        {
            throw new Exception("A data da entrega é obrigatória");
        }

        return repository.Atualizar(id, entrega);
    }

    public bool Deletar(int id)
    {
        bool entregaExistente = repository.Deletar(id);
        if (!entregaExistente)
        {
            throw new Exception("Entrega não encontrada");
        }

        return entregaExistente;
    }

}
