using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public class Favorito
{
    [FirestoreProperty]
    public int IdMovel {get; set;}

}