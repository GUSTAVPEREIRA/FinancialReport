using System.Data.Common;
using Npgsql;

namespace FinancialReport.Infrastructure.Providers;

public class PostgresDatabaseProvider : IDatabaseProvider
{
    public DbConnection Connection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }
}