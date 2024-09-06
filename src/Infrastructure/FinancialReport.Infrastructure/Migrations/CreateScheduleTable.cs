using System.Data;
using FluentMigrator;

namespace FinancialReport.Infrastructure.Migrations;

public class CreateScheduleTable : Migration
{
    public override void Up()
    {
        Execute.Sql("CREATE TYPE SCHEDULE_TYPE AS ENUM ('Daily', 'Weekly', 'Monthly');");

        Create.Table("Schedule")
            .WithColumn("id").AsGuid().PrimaryKey().NotNullable().WithDefaultValue(Guid.NewGuid())
            .WithColumn("repeat").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("sendEmail").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("type").AsCustom("SCHEDULE_TYPE").NotNullable().WithDefaultValue("Daily");

        Create.ForeignKey().FromTable("FK_SCHEDULE_USER").ForeignColumn("userId")
            .ToTable("User").PrimaryColumn("id").OnDelete(Rule.Cascade);
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_SCHEDULE_USER").OnTable("Schedule");
        Delete.Table("Schedule");
        Execute.Sql("DROP TYPE IF EXISTS schedule_type;");
    }
}