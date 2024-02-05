using Serilog;

namespace WebApp.Extensions;

public static class HostExtensions
{
    public static IHostBuilder SetupSerilog(this IHostBuilder host)
    {
        return host.UseSerilog((context, provider, config) => config
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(provider)
            .Enrich.FromLogContext()
            .WriteTo.Console());
    }
}
