using Domain;
using Domain.Abstractions;

namespace Servicios.UseCases;

public class DeleteWordUseCase
{
    private readonly IRepository<Word> _repository;

    public DeleteWordUseCase(IRepository<Word> repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        var word = await _repository.GetByIdAsync(id);
        if (word == null)
            throw new KeyNotFoundException("La palabra solicitada no existe.");

        await _repository.DeleteAsync(word);
    }
}
