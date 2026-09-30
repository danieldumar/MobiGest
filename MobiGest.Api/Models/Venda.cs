using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public class Venda
{
    [FirestoreProperty]
    public int Id {get; set;}
    [FirestoreProperty]
    public int IdCliente {get; set;}
    [FirestoreProperty]
    public DateTime Data {get; set;}
    [FirestoreProperty]
    public decimal VendaTotal {get; set;}

}