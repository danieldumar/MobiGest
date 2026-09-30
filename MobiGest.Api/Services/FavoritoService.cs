using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class FavoritoService
{
    private readonly FavoritoRepository repository;

    public FavoritoService(FavoritoRepository repository)
    {
        this.repository = repository;    
    }

    public List<Favorito> GetTodos()
    {
        return repository.GetTodos();
    }

    public Favorito? GetPorId(int idMovel)
    {
        Favorito? favorito = repository.GetPorId(idMovel);
        if (favorito == null)
        {
            throw new Exception("Favorito não encontrado");
        }
        return favorito;
    }

    public void Criar(Favorito favorito)
    {
        repository.Criar(favorito);
    }

    public bool Atualizar(int idMovel)
    {
        return repository.Atualizar(idMovel);
    }

    public bool Deletar(int idMovel)
    {
        bool favoritoExistente = repository.Deletar(idMovel);
        if (!favoritoExistente)
        {
            throw new Exception("Favorito não encontrado");
        }

        return repository.Deletar(idMovel);
    }

}