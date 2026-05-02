using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Servicios.Dtos;
using Servicios.UseCases;

namespace WebApi.Endpoints;

public static class WordEndpoints
{
    public static void MapWordEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/words");

        group.MapPost("/", async (CreateWordDto dto, CreateWordUseCase useCase) =>
        {
            var word = await useCase.ExecuteAsync(dto);
            return Results.Created($"/api/words/{word.Id}", word);
        })
        .WithName("CreateWord")
        .Produces<Domain.Word>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        group.MapGet("/", async (GetAllWordsUseCase useCase) =>
        {
            var words = await useCase.ExecuteAsync();
            return Results.Ok(words);
        })
        .WithName("GetAllWords")
        .Produces<IReadOnlyList<Domain.Word>>();

        group.MapGet("/{id:int}", async (int id, GetWordByIdUseCase useCase) =>
        {
            var word = await useCase.ExecuteAsync(id);
            return word is not null ? Results.Ok(word) : Results.NotFound();
        })
        .WithName("GetWordById")
        .Produces<Domain.Word>()
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id:int}", async (int id, UpdateWordDto dto, UpdateWordUseCase useCase) =>
        {
            var word = await useCase.ExecuteAsync(id, dto);
            return Results.Ok(word);
        })
        .WithName("UpdateWord")
        .Produces<Domain.Word>()
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        group.MapDelete("/{id:int}", async (int id, DeleteWordUseCase useCase) =>
        {
            await useCase.ExecuteAsync(id);
            return Results.NoContent();
        })
        .WithName("DeleteWord")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
