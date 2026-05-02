using Domain;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository;

public class WordRepository : IRepository<Word>
{
    private readonly AppDbContext _context;

    public WordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Word?> GetByIdAsync(Guid id)
    {
        return await _context.Words.FindAsync(id);
    }

    public async Task<IReadOnlyList<Word>> GetAllAsync()
    {
        return await _context.Words.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Word entity)
    {
        await _context.Words.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Word entity)
    {
        _context.Words.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Word entity)
    {
        _context.Words.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
