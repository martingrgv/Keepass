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

            if (!Login())
            {
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        private bool Login()
        {
            var loginWindow = _loginFactory.Create();
            bool isLoginSuccess = (bool)loginWindow.ShowDialog()!;

            if (!isLoginSuccess)
            {
                return false;
            }

            return true;
        }

        private void btnCreateSecrets_Click(object sender, RoutedEventArgs e)
        {
            var createSecretWindow = _createFactory.Create();
            createSecretWindow.ReloadSecrets += ReloadSecrets;
            createSecretWindow.Show();
        }

        private async void ReloadSecrets(object? sender, EventArgs e)
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);
            var secretList = result.Adapt<SecretListViewModel>();

            dataGridSecrets.ItemsSource = secretList.Secrets;
        }
    }
}
