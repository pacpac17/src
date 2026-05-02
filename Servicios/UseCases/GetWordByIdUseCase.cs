using Domain;
using Domain.Abstractions;

namespace Servicios.UseCases;

public class GetWordByIdUseCase
{
    private readonly IRepository<Word> _repository;

    public GetWordByIdUseCase(IRepository<Word> repository)
    {
        _repository = repository;
    }

    public async Task<Word?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
