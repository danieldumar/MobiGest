using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class ItemVendaService
{
    private readonly ItemVendaRepository repository;

    public ItemVendaService(ItemVendaRepository repository)
    {
        this.repository = repository;    
    }

    public List<ItemVenda> GetTodos()
    {
        return repository.GetTodos();
    }

    public ItemVenda? GetPorId(int id)
    {
        ItemVenda? itemVenda = repository.GetPorId(id);
        if (itemVenda == null)
        {
            throw new Exception("Item de venda não encontrado");
        }
        return itemVenda;
    }

    public void Criar(ItemVenda itemVenda)
    {
        if (string.IsNullOrWhiteSpace(itemVenda.NomeItem))
        {
            throw new Exception("O nome do item de venda é obrigatório");
        }

        if (itemVenda.ValorUnitario <= 0)
        {
            throw new Exception("O valor unitário do item de venda deve ser maior que zero");
        }

        if (itemVenda.Quantidade <= 0)
        {
            throw new Exception("A quantidade do item de venda deve ser maior que zero");
        }

        repository.Criar(itemVenda);
    }

    public bool Atualizar(int id, ItemVenda itemVenda)
    {
        if (string.IsNullOrWhiteSpace(itemVenda.NomeItem))
        {
            throw new Exception("O nome do item de venda é obrigatório");
        }

        if (itemVenda.ValorUnitario <= 0)
        {
            throw new Exception("O valor unitário do item de venda deve ser maior que zero");
        }

        if (itemVenda.Quantidade <= 0)
        {
            throw new Exception("A quantidade do item de venda deve ser maior que zero");
        }

        return repository.Atualizar(id, itemVenda);
    }

    public bool Deletar(int id)
    {
        bool itemVendaExistente = repository.Deletar(id);
        if (!itemVendaExistente)
        {
            throw new Exception("Item de venda não encontrado");
        }
        return itemVendaExistente;
    }

}
