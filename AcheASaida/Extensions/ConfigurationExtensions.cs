namespace AcheASaida.Extensions;

public static class ConfigurationExtensions
{
    public static void AddConfigurations(this ConfigurationManager configuration)
    {
        configuration.AddJsonFile("appsettings.json");
        configuration.AddEnvironmentVariables();
    }
}