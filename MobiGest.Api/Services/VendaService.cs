using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class VendaService
{
    private readonly VendaRepository repository;

    public VendaService(VendaRepository repository)
    {
        this.repository = repository;    
    }

    public List<Venda> GetTodos()
    {
        return repository.GetTodos();
    }

    public Venda? GetPorId(int id)
    {
        Venda? venda = repository.GetPorId(id);
        if (venda == null)
        {
            throw new Exception("Venda não encontrada");
        }
        return venda;
    }

    public void Criar(Venda venda)
    {
        if (venda.Data == default(DateTime))
        {
            throw new Exception("A data da venda é obrigatória");
        }

        repository.Criar(venda);
    }

    public bool Atualizar(int id, Venda venda)
    {
        if (string.IsNullOrWhiteSpace(venda.Data.ToString()))
        {
            throw new Exception("A data da venda é obrigatória");
        }

        return repository.Atualizar(id, venda);
    }

    public bool Deletar(int id)
    {
        bool vendaExistente = repository.Deletar(id);
        if (!vendaExistente)
        {
            throw new Exception("Venda não encontrada");
        }

        return true;
    }

}