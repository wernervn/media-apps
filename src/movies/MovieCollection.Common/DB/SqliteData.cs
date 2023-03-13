using Dapper;
using Microsoft.Data.Sqlite;

namespace MovieCollection.Common.DB;
internal static class SqliteData
{
    #region ExecuteNonQueryAsync

    public static async Task ExecuteCommandAsync(string dbPath, string sql)
    {
        using var cn = await GetConnectionAsync(dbPath).ConfigureAwait(false);

        await cn.ExecuteAsync(sql).ConfigureAwait(false);
    }

    public static async Task ExecuteCommandAsync(string dbPath, string sql, Dictionary<string, object> parameters)
    {
        using var cn = await GetConnectionAsync(dbPath).ConfigureAwait(false);

        await cn.ExecuteAsync(sql, new DynamicParameters(parameters)).ConfigureAwait(false);
    }

    public static async Task ExecuteCommandsAsync(string dbPath, IEnumerable<string> sqlStatements)
    {
        using var cn = await GetConnectionAsync(dbPath).ConfigureAwait(false);

        foreach (var sql in sqlStatements)
        {
            await cn.ExecuteAsync(sql).ConfigureAwait(false);
        }
    }

    #endregion ExecuteNonQueryAsync

    #region Query
    public static async Task<TEntity> QuerySingleAsync<TEntity>(string dbPath, string sql)
        where TEntity : class, new()
    {
        using var cn = await GetConnectionAsync(dbPath).ConfigureAwait(false);

        return await cn.QuerySingleOrDefaultAsync<TEntity>(sql).ConfigureAwait(false);
    }

    public static async Task<List<TEntity>> QueryAsync<TEntity>(string dbPath, string sql) where TEntity : class, new()
    {
        using var cn = await GetConnectionAsync(dbPath).ConfigureAwait(false);

        return (await cn.QueryAsync<TEntity>(sql)).ToList();
    }
    #endregion Query

    #region Helpers

    private static async Task<SqliteConnection> GetConnectionAsync(string path)
    {
        var cn = new SqliteConnection(string.Format("Data Source={0}", path));
        await cn.OpenAsync().ConfigureAwait(false);
        return cn;
    }

    public static string CleanSQL(string text)
        => text.Replace("'", "''");

    #endregion Helpers
}
