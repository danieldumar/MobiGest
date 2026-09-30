using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public class Entrega
{
    [FirestoreProperty]
    public int Id {get; set;}
    [FirestoreProperty]
    public int IdVenda {get; set;}
    [FirestoreProperty]
    public string Endereco {get; set;} = "";
    [FirestoreProperty]
    public DateTime Data {get; set;}
    [FirestoreProperty]
    public string Comentario {get; set;} = "";

}