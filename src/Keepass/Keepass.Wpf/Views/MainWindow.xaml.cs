using Keepass.Application.Secrets.Queries.GetSecrets;
using MediatR;
namespace Keepass.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private ISender _sender;

        public MainWindow(ISender sender)
        {
            _sender = sender;

            InitializeComponent();
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
