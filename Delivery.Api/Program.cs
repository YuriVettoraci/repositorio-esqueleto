using Delivery.Api;
using Delivery.Api.Extension;
using Serilog;

public class Program
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

        try
        {
            Log.Information("Iniciando aplicação");

            BuildWebApplication(args);
        }
        catch(Exception ex)
        {

        }
    }

    public static void BuildWebApplication(string[] args)
    {
        string porta = Configuration.GetSection("Aplicacao:Porta").Value;

        WebApplication.CreateBuilder(args).UseStartup<Startup>(Configuration);
    }
}