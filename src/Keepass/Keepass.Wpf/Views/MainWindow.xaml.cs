using Keepass.Application.Secrets.Queries.GetSecrets;

namespace Keepass.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private readonly ISender _sender;
        private readonly IFormAbstractFactory<LoginWindow> _loginFactory;
        private readonly IFormAbstractFactory<CreateSecretWindow> _createFactory;

        public MainWindow(
            ISender sender,
            IFormAbstractFactory<LoginWindow> loginFactory,
            IFormAbstractFactory<CreateSecretWindow> createFactory)
        {
            _sender = sender;
            _loginFactory = loginFactory;
            _createFactory = createFactory;

            Login();
            InitializeComponent();
            LoadSecrets();
        }

        private void Login()
        {
            var loginWindow = _loginFactory.Create();
            var value = loginWindow.ShowDialog();
        }

        private void btnCreateSecrets_Click(object sender, RoutedEventArgs e)
        {
            var createSecretWindow = _createFactory.Create();
            createSecretWindow.ReloadSecrets += ReloadSecrets;
            createSecretWindow.Show();
        }

        private void ReloadSecrets(object? sender, EventArgs e)
        {
            LoadSecrets();
        }
        
        private async void LoadSecrets()
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);
            var secretList = result.Adapt<SecretListViewModel>();

            dataGridSecrets.ItemsSource = secretList.Secrets;
        }
    }
}
