using Domain;
using Domain.Abstractions;
using Servicios.Dtos;

namespace Servicios.UseCases;

public class CreateWordUseCase
{
    private readonly IRepository<Word> _repository;

    public CreateWordUseCase(IRepository<Word> repository)
    {
        _repository = repository;
    }

    public async Task<Word> ExecuteAsync(CreateWordDto dto)
    {
        var word = new Word(dto.Name);
        await _repository.AddAsync(word);
        return word;
    }
}
