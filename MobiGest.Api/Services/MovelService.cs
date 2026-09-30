using MobiGest.Api.Models;
using MobiGest.Api.Repositories;

namespace MobiGest.Api.Services;

public class MovelService
{
    private readonly MovelRepository repository;

    public MovelService(MovelRepository repository)
    {
        this.repository = repository;    
    }

    public List<Movel> GetTodos()
    {
        return repository.GetTodos();
    }

    public Movel? GetPorId(int id)
    {
        return repository.GetPorId(id);
    }

    public void Criar(Movel movel)
    {
        if (string.IsNullOrWhiteSpace(movel.Nome))
        {
            throw new Exception("O nome do móvel é obrigatório");
        }

        if (movel.Preco <= 0)
        {
            throw new Exception("O preço do móvel deve ser maior que zero");
        }

        if (movel.Estoque < 0)
        {
            throw new Exception("O estoque do móvel não pode ser negativo");
        }

        repository.Criar(movel);
    }

    public bool Atualizar(int id, Movel movel)
    {
        if (string.IsNullOrWhiteSpace(movel.Nome))
        {
            throw new Exception("O nome do móvel é obrigatório");
        }

        if (movel.Preco <= 0)
        {
            throw new Exception("O preço do móvel deve ser maior que zero");
        }

        if (movel.Estoque < 0)
        {
            throw new Exception("O estoque do móvel não pode ser negativo");
        }

        return repository.Atualizar(id, movel);
    }

    public bool Deletar(int id)
    {
        return repository.Deletar(id);
    }

}
