using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using projekt_CSharp.Data;
namespace projekt_CSharp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<KursyContext>(options => options.UseNpgsql(connectionString));
                })
                .Build();

            ServiceProvider = host.Services;
            var context = ServiceProvider.GetRequiredService<KursyContext>();
            // Uruchamia g��wne okno aplikacji (MenuForm), przekazuj�c mu dostawc� us�ug i kontekst bazy danych.
            Application.Run(new MenuForm(ServiceProvider, context));
        }
    }
}