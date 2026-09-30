using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class EntregaRepository
{
    private List<Entrega> entregas = new List<Entrega>();
    private int proximoId = 1;
    public List<Entrega> GetTodos()
    {
        return entregas;
    }

    public Entrega? GetPorId(int Id)
    {
        return entregas.FirstOrDefault(entrega => entrega.Id == Id);
    }

    public void Criar(Entrega entrega)
    {
        entrega.Id = proximoId++;
        entregas.Add(entrega);
    }

    public bool Atualizar(int id, Entrega entrega)
    {
        Entrega? entregaExistente = GetPorId(id); 
        if (entregaExistente == null)
        {
            return false;
        }       

        entregaExistente.Endereco = entrega.Endereco;
        entregaExistente.Data = entrega.Data;
        entregaExistente.Comentario = entrega.Comentario;
        return true;
    }
    public bool Deletar(int id)
    {
        Entrega? entregaExistente = GetPorId(id);

        if (entregaExistente == null)
        {
            return false;
        }

        entregas.Remove(entregaExistente);
        return true;    
    }


}