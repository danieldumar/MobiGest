using MobiGest.Api.Models;
using Google.Cloud.Firestore;
namespace MobiGest.Api.Repositories;

public class MovelRepository
{
    private readonly FirestoreDb db;

    public MovelRepository(FirestoreDb db)
    {
        this.db = db;
    }

    public async Task<List<Movel>> GetTodos()
    {
        QuerySnapshot snapshot = await db.Collection("moveis").GetSnapshotAsync();

        List<Movel> moveis = new ();
        foreach (DocumentSnapshot document in snapshot.Documents)
        {
            if (document.Exists)
            {
                Movel movel = document.ConvertTo<Movel>();
                moveis.Add(movel);
            }
        }
        return moveis;
    }

    public async Task<Movel?> GetPorId(int id)
    {
        DocumentReference docRef = db.Collection("moveis").Document(id.ToString());
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            return snapshot.ConvertTo<Movel>();
        }
        return null;
    }

    public async Task Criar(Movel movel)
    {
        QuerySnapshot snapshot = await db.Collection("moveis").GetSnapshotAsync();
        int proximoId = 1;


        if (snapshot.Documents.Count > 0)
        {
            proximoId = snapshot.Documents.Select(documento => documento.ConvertTo<Movel>().Id).Max() + 1;
        } 
        movel.Id = proximoId;
        DocumentReference docRef = db.Collection("moveis").Document(movel.Id.ToString());
        await docRef.SetAsync(movel);
    }

    public async Task<bool> Atualizar(int id, Movel movel)
    {
        Movel? movelExistente = await GetPorId(id);
        if (movelExistente == null)
        {
            return false;
        }       

        movelExistente.Nome = movel.Nome;
        movelExistente.Descricao = movel.Descricao;
        movelExistente.Preco = movel.Preco;
        movelExistente.Estoque = movel.Estoque;
        movelExistente.Categoria = movel.Categoria;
        return true;
    }

    public async Task<bool> Deletar(int id)
    {
        Movel? movelExistente = await GetPorId(id);

        if (movelExistente == null)
        {
            return false;
        }

        DocumentReference docRef = db.Collection("moveis").Document(movelExistente.Id.ToString());
        await docRef.DeleteAsync();
        return true;    
    }

}


