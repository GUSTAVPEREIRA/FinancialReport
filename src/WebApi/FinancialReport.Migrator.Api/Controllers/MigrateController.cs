using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc;

namespace FinancialReport.Migrator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MigrateController(IMigrationRunner migrationRunner) : ControllerBase
{
    [HttpPost("Up")]
    public IActionResult UpdateDatabase()
    {
        try
        {
            if (migrationRunner.HasMigrationsToApplyUp())
            {
                migrationRunner.MigrateUp();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError,
                title: "Failed doing migrate");
        }
    }

    [HttpPost("Down/{version}")]
    public IActionResult DowngradeDatabase(long version)
    {
        try
        {
            if (migrationRunner.HasMigrationsToApplyDown(version))
            {
                migrationRunner.MigrateDown(version);
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError,
                title: "Failed doing migrate");
        }
    }
}