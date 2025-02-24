using Keepass.Application.Secrets.Commands.ImportSecrets;
using Keepass.Application.Secrets.Queries.ExportSecretList;
using Keepass.Application.Secrets.Queries.GetSecrets;
using Microsoft.Win32;

namespace Keepass.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private readonly ISender _sender;
        private readonly IFormAbstractFactory<LoginWindow> _loginFactory;
        private readonly IFormAbstractFactory<CreateSecretWindow> _createFactory;
        private readonly SecretCollectionViewModel _viewModel;

        public MainWindow(
            ISender sender,
            IFormAbstractFactory<LoginWindow> loginFactory,
            IFormAbstractFactory<CreateSecretWindow> createFactory,
            SecretCollectionViewModel mainViewModel)
        {
            _sender = sender;
            _loginFactory = loginFactory;
            _createFactory = createFactory;
            _viewModel = mainViewModel;

            DataContext = _viewModel;

            if (!Login())
            {
                Environment.Exit(0);
            }

            InitializeComponent();
            LoadSecrets();
        }


        private void btnCreateSecrets_Click(object sender, RoutedEventArgs e)
        {
            var createSecretWindow = _createFactory.Create();
            createSecretWindow.Show();
        }

        private async void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() == false)
            {
                return;
            }

            string filePath = ofd.FileName;
            var result = await _sender.Send(new ImportSecretsCommand(filePath));

            if (result.IsSuccess)
            {
                //statusBarBlockExtracted.Text = "Imported";
            };
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                FileName = "secrets.json",
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };


            if (sfd.ShowDialog() == false)
            {
                return;
            }

            string filePath = sfd.FileName;
            var result = await _sender.Send(new ExportSecretsQuery(filePath));

            if (result.IsSuccess)
            {
                //statusBarBlockExtracted.Text = "Extracted";
            }
        }


        private async void LoadSecrets()
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);
            foreach (var secret in result.Secrets)
            {
                var secretViewModel = secret.Adapt<SecretViewModel>();
                _viewModel.Secrets.Add(secretViewModel);
            }
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
    }
}
