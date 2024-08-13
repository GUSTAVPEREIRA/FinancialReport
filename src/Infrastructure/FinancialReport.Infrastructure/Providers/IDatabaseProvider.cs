using System.Data.Common;

namespace FinancialReport.Infrastructure.Providers;

public interface IDatabaseProvider
{
    DbConnection Connection(string connectionString);
}