using FinancialReport.Core.Configuration.Extension;
using FluentMigrator.Runner;
using static FinancialReport.Infrastructure.Migrations.MigrationConfiguration;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSetting();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentMigratorCore();
builder.Services.ConfigureRunner(x =>
{
    x.AddPostgres();
    x.WithGlobalConnectionString(settings.Database.ConnectionString);
    x.ScanIn(GetMigrations()).For.Migrations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
