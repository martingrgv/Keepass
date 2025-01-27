using Keepass.Wpf.Views;

namespace Keepass.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private IServiceProvider _serviceProvider = null!;
        private IConfiguration _configuration = null!;

        public App()
        {
             _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();

            _serviceProvider = new ServiceCollection()
                .AddInfrastructure(_configuration)
                .AddApplication()
                .AddSingleton<MainWindow>()
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
