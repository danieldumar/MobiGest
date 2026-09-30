using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public class Cliente
{
    [FirestoreProperty]
    public int Id {get; set;}
    [FirestoreProperty]
    public string Nome {get; set;} = "";
    [FirestoreProperty]
    public string Endereco {get; set;} = "";
    [FirestoreProperty]
    public string Telefone {get; set;} = "";
    [FirestoreProperty]
    public string Comentario {get; set;} = "";

}