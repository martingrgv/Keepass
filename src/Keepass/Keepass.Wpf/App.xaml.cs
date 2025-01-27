
namespace Keepass.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private IServiceProvider _serviceProvider = null!;
        private IConfiguration _configuration = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();

            _serviceProvider = new ServiceCollection()
                .AddInfrastructure(_configuration)
                .AddApplication()
                .BuildServiceProvider();

            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
