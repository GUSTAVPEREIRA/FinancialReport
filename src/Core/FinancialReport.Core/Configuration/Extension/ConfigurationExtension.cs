using Microsoft.Extensions.Configuration;

namespace FinancialReport.Core.Configuration.Extension;

public static class ConfigurationExtension
{
    public static Setting GetSetting(this IConfiguration configuration)
    {
        var setting = configuration.Get<Setting>();

        return setting ?? throw new NullReferenceException("The environment variables cannot be null.");
    }
}