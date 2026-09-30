using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public enum TiposCategoria
{
    Mesa, Cadeira, Armario, Planejado
}

public class Movel
{
    [FirestoreProperty]
    public int Id {get; set;}
    [FirestoreProperty]
    public string Nome {get; set;} = "";
    [FirestoreProperty]
    public string Descricao {get; set;} = "";
    [FirestoreProperty]
    public double Preco {get; set;}
    [FirestoreProperty]
    public int Estoque {get; set;}
    [FirestoreProperty]
    public TiposCategoria Categoria {get; set;}
}
