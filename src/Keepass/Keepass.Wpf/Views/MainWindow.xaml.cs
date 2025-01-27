using Keepass.Application.Secrets.Queries.GetSecrets;
using Keepass.Wpf.Contracts;

namespace Keepass.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private readonly ISender _sender;
        private readonly IFormAbstractFactory<LoginWindow> _factory;

        public MainWindow(ISender sender, IFormAbstractFactory<LoginWindow> factory)
        {
            _sender = sender;
            _factory = factory;

            Login();
            InitializeComponent();
        }

        private void Login()
        {
            var loginWindow = _factory.Create();
            var value = loginWindow.ShowDialog();
        }

        private async void btnReloadSecrets_Click(object sender, RoutedEventArgs e)
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);

            dataGridSecrets.ItemsSource = result.Secrets;
        }

        private void btnCreateSecrets_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
