using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Extensions;
using Servicios.UseCases;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepository(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddScoped<CreateWordUseCase>();
builder.Services.AddScoped<GetWordByIdUseCase>();
builder.Services.AddScoped<GetAllWordsUseCase>();
builder.Services.AddScoped<UpdateWordUseCase>();
builder.Services.AddScoped<DeleteWordUseCase>();

var app = builder.Build();

app.MapWordEndpoints();

await using var scope = app.Services.CreateAsyncScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await db.Database.MigrateAsync();

if (!await db.Words.AnyAsync())
{
    await db.Words.AddRangeAsync(
        new Word("Epifanía", "Manifestación repentina de una verdad o comprensión profunda"),
        new Word("Resiliencia", "Capacidad de adaptarse y superar adversidades"),
        new Word("Serendipia", "Hallazgo afortunado e inesperado que se produce cuando se busca otra cosa"),
        new Word("Efímero", "Aquello que dura por un período muy corto de tiempo"),
        new Word("Inefable", "Algo tan extraordinario que no puede expresarse con palabras")
    );
    await db.SaveChangesAsync();
}

app.Run();
