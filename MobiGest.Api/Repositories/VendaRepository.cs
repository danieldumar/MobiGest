using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class VendaRepository
{
    private List<Venda> vendas = new List<Venda>();
    private int proximoId = 1;

    public List<Venda> GetTodos()
    {
        return vendas;
    }

    public Venda? GetPorId(int id)
    {
        return vendas.FirstOrDefault(venda => venda.Id == id);
    }

    public void Criar(Venda venda)
    {
        vendas.Add(venda);
    }

    public bool Atualizar(int id, Venda venda)
    {
        Venda? vendaExistente = GetPorId(id);
        if (vendaExistente == null)
        {
            return false;
        }       

        vendaExistente.Data = venda.Data;
        vendaExistente.VendaTotal = venda.VendaTotal;
        return true;
    }

    public bool Deletar(int id)
    {
        Venda? vendaExistente = GetPorId(id);

        if (vendaExistente == null)
        {
            return false;
        }

        vendas.Remove(vendaExistente);
        return true;    
    }

}


