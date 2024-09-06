using System.Reflection;

namespace FinancialReport.Infrastructure.Migrations;

public static class MigrationConfiguration
{
    public static Assembly[] GetMigrations()
    {
        return
        [
            typeof(CreateUserTable).Assembly,
            typeof(CreateScheduleTable).Assembly
        ];
    }
}