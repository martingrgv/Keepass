using Keepass.Application.Secrets.Queries.ExportSecretList;
using Keepass.Application.Secrets.Queries.GetSecrets;
using Microsoft.Win32;
using System.IO;

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

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string directoryPath = string.Empty;

            var ofd = new OpenFolderDialog()
            {
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };


            if (ofd.ShowDialog() == true)
            {
                directoryPath = ofd.FolderName;
            }

            var result = await _sender.Send(new ExportSecretListQuery());

            byte[] fileBytes = result.FileBytes;
            string filePath = Path.Combine(directoryPath, "secrets.json");

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(fileBytes);
            }    
        }
    }
}
