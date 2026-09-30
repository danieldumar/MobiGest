using MobiGest.Api.Models;
namespace MobiGest.Api.Repositories;

public class FavoritoRepository
{
    private List<Favorito> favoritos = new List<Favorito>();

    public List<Favorito> GetTodos()
    {
        return favoritos;
    }

    public Favorito? GetPorId(int idMovel)
    {
        return favoritos.FirstOrDefault(favorito => favorito.IdMovel == idMovel);
    }

    public void Criar(Favorito favorito)
    {
        favoritos.Add(favorito);
    }

    public bool Atualizar(int idMovel)
    {
        Favorito? favoritoExistente = GetPorId(idMovel); 
        if (favoritoExistente == null)
        {
            return false;
        }       

        return true;
    }

    public bool Deletar(int idMovel)
    {
        Favorito? favoritoExistente = GetPorId(idMovel);

        if (favoritoExistente == null)
        {
            return false;
        }

        favoritos.Remove(favoritoExistente);
        return true;    
    }

}