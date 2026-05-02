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

app.Run();
