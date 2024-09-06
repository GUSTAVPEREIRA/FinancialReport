using FluentMigrator;

namespace FinancialReport.Infrastructure.Migrations;

public class CreateUserTable : Migration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(Guid.NewGuid())
            .WithColumn("email").AsString(500).NotNullable().Unique("user_email").Indexed()
            .WithColumn("password").AsString(1000).NotNullable()
            .WithColumn("activated").AsBoolean().NotNullable().WithDefaultValue(false);
    }
 
    public override void Down()
    {
        Delete.Table("user");
    }
}