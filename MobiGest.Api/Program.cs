using MobiGest.Api.Repositories;
using MobiGest.Api.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Espaço Firebase
var credential = CredentialFactory.FromFile<ServiceAccountCredential>("firebase-key.json").ToGoogleCredential();
var firestoreDb = new FirestoreDbBuilder
{
    ProjectId = "mobigestlocal",
    Credential = credential
}.Build();

builder.Services.AddSingleton(firestoreDb);


builder.Services.AddSingleton<MovelRepository>();
builder.Services.AddSingleton<MovelService>();

builder.Services.AddSingleton<ClienteRepository>();
builder.Services.AddSingleton<ClienteService>();

builder.Services.AddSingleton<EntregaRepository>();
builder.Services.AddSingleton<EntregaService>();

builder.Services.AddSingleton<FavoritoRepository>();
builder.Services.AddSingleton<FavoritoService>();

builder.Services.AddSingleton<ItemVendaRepository>();
builder.Services.AddSingleton<ItemVendaService>();

builder.Services.AddSingleton<UsuarioRepository>();
builder.Services.AddSingleton<UsuarioService>();

builder.Services.AddSingleton<VendaRepository>();
builder.Services.AddSingleton<VendaService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
