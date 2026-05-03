using Dapper;
using Domain;
using Domain.Abstractions;
using MySqlConnector;

namespace Repository;

public class WordRepository : IRepository<Word>
{
    private readonly MySqlConnection _connection;

    public WordRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<Word?> GetByIdAsync(int id)
    {
        const string sql = "SELECT pal_id as Id , word as Name FROM palabras WHERE pal_id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<Word>(sql, new { Id = id });
    }

    public async Task<IReadOnlyList<Word>> GetAllAsync()
    {
        //const string sql = "SELECT english_id as Id , word as Name FROM english  WHERE english_id LIMIT 10";
        const string sql = "SELECT pal_id as Id , word as Name FROM palabras  WHERE pal_id LIMIT 10";
        return (await _connection.QueryAsync<Word>(sql)).ToList();
    }

    public async Task AddAsync(Word entity)
    {
        const string sql = "INSERT INTO palabras (word) VALUES (@Name)";
        await _connection.ExecuteAsync(sql, new { entity.Name });
    }

    public async Task UpdateAsync(Word entity)
    {
        const string sql = "UPDATE palabras SET word = @Name WHERE pal_id = @Id";
        await _connection.ExecuteAsync(sql, new { entity.Id, entity.Name });
    }

    public async Task DeleteAsync(Word entity)
    {
        const string sql = "DELETE FROM palabras WHERE pal_id = @Id";
        await _connection.ExecuteAsync(sql, new { entity.Id });
    }
}
