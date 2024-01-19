using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using Web.Repositories;

namespace Web.Utils;

/// <summary>
/// Класс для обращения к последовательностям БД
/// </summary>
/// <param name="dbContextFactory"></param>
public class SequencesHelper(IDbContextFactory<ApplicationContext> dbContextFactory)
{
    private const string SelectNextval = "SELECT nextval(@name) AS result";

    /// <summary>
    /// Возвращает следующее значение, сгенерированное заданной последовательностью
    /// </summary>
    /// <param name="sequenceName"> Имя последовательности </param>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Следующее значение последовательности </returns>
    public async Task<long> GetNextSequenceValue(string sequenceName, CancellationToken token)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(token);

        var result = new NpgsqlParameter("result", NpgsqlDbType.Bigint)
        {
            Direction = ParameterDirection.Output
        };

        var nameParameter = new NpgsqlParameter("@name", NpgsqlDbType.Text)
        {
            Direction = ParameterDirection.Input,
            Value = sequenceName
        };

        object[] parameters = { nameParameter, result };

        await dbContext.Database.ExecuteSqlRawAsync(SelectNextval, parameters);

        ArgumentNullException.ThrowIfNull(result.Value);
        return (long)result.Value;
    }
}