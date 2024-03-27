using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TechTest.Repositories.Extensions;
using Parcel2Go.TechTest.Services.Extensions;

namespace Scanner
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ServiceProvider = CreateHostBuilder().Build().Services;

            Application.Run(ServiceProvider.GetService<Form1>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddRepositories();
                    services.AddServices();
                    services.AddTransient<Form1>();
                });
        }
    }
}