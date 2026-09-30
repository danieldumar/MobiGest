using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class ItemVendaRepository
{
    private List<ItemVenda> itensVenda = new List<ItemVenda>();
    private int proximoId = 1;

    public List<ItemVenda> GetTodos()
    {
        return itensVenda;
    }

    public ItemVenda? GetPorId(int id)
    {
        return itensVenda.FirstOrDefault(item => item.Id == id);
    }

    public void Criar(ItemVenda item)
    {
        item.Id = proximoId++;
        itensVenda.Add(item);
    }

    public bool Atualizar(int id, ItemVenda item)
    {
        ItemVenda? itemExistente = GetPorId(id);
        if (itemExistente == null)
        {
            return false;
        }       

        itemExistente.NomeItem = item.NomeItem;
        itemExistente.ValorUnitario = item.ValorUnitario;
        itemExistente.Quantidade = item.Quantidade;
        return true;
    }

    public bool Deletar(int id)
    {
        ItemVenda? itemExistente = GetPorId(id);

        if (itemExistente == null)
        {
            return false;
        }

        itensVenda.Remove(itemExistente);
        return true;    
    }

}