using Domain;
using Domain.Abstractions;

namespace Servicios.UseCases;

public class GetAllWordsUseCase
{
    private readonly IRepository<Word> _repository;

    public GetAllWordsUseCase(IRepository<Word> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Word>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
