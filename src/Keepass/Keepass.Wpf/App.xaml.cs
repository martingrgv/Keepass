using Keepass.Wpf.Extensions;
using Keepass.Wpf.Views;
using Microsoft.Extensions.Hosting;

namespace Keepass.Wpf
{
    public partial class App : System.Windows.Application
    {
        private readonly IConfiguration _configuration; 
        public static IHost? AppHost { get; private set; }

        public App()
        {
             _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddInfrastructure(_configuration)
                    .AddApplication()
                    .AddPresentation();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
