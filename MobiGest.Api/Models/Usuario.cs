using Google.Cloud.Firestore;
namespace MobiGest.Api.Models;

[FirestoreData]
public enum TiposUsuario
{
    Administrador,
    Vendedor
}

public class Usuario
{
    [FirestoreProperty]
    public int Id { get; set; }
    [FirestoreProperty]
    public string Nome { get; set; } = "";
    [FirestoreProperty]
    public string Email { get; set; } = "";
    [FirestoreProperty]
    public TiposUsuario Tipo { get; set; }
}