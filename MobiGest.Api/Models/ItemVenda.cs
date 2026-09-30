using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public class ItemVenda
{
    [FirestoreProperty]
    public int Id {get; set;}
    [FirestoreProperty]
    public int IdVenda {get; set;}
    [FirestoreProperty]
    public int IdMovel {get; set;}
    [FirestoreProperty]
    public string NomeItem {get; set;} = "";
    [FirestoreProperty]
    public decimal ValorUnitario {get; set;}
    [FirestoreProperty]
    public int Quantidade {get; set;}

}