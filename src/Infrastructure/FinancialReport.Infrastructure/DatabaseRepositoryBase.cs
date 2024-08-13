using System.Data.Common;
using FinancialReport.Core.Configuration.Extension;
using FinancialReport.Infrastructure.Providers;
using Microsoft.Extensions.Configuration;

namespace FinancialReport.Infrastructure;

public abstract class DatabaseRepositoryBase
{
    private readonly IDatabaseProvider _databaseProvider;
    private readonly string _connectionString;

    protected DatabaseRepositoryBase(IConfiguration configuration, IDatabaseProvider databaseProvider)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        var setting = configuration.GetSetting();

        _connectionString = setting.Database.ConnectionString;
        _databaseProvider = databaseProvider;
    }

    protected DbConnection GetConnection()
    {
        return _databaseProvider.Connection(_connectionString);
    }
}