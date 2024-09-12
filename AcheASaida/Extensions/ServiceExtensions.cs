using AcheASaida.Data;

namespace AcheASaida.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
    }
}