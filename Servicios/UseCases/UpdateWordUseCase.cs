using Domain;
using Domain.Abstractions;
using Servicios.Dtos;

namespace Servicios.UseCases;

public class UpdateWordUseCase
{
    private readonly IRepository<Word> _repository;

    public UpdateWordUseCase(IRepository<Word> repository)
    {
        _repository = repository;
    }

    public async Task<Word> ExecuteAsync(Guid id, UpdateWordDto dto)
    {
        var word = await _repository.GetByIdAsync(id);
        if (word == null)
            throw new KeyNotFoundException("La palabra solicitada no existe.");

        word.UpdateName(dto.Name);
        word.UpdateMeaning(dto.Meaning);

        await _repository.UpdateAsync(word);
        return word;
    }
}
