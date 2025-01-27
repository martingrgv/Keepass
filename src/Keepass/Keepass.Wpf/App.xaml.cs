using Keepass.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Keepass.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            string connectionString = "Server=localhost;Database=KeepassDb;Integrated Security=True;TrustServerCertificate=True";

            _serviceProvider = new ServiceCollection()
                .RegisterDatabase(connectionString)
                .RegisterServices()
                .BuildServiceProvider();

            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }

}
