
using Keepass.Application.Secrets.Commands.ImportSecretList;

namespace Keepass.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private readonly ISender _sender;
        private readonly IFormAbstractFactory<LoginWindow> _loginFactory;
        private readonly IFormAbstractFactory<CreateSecretWindow> _createFactory;
        private readonly string defaultExportFilePath;

        public MainWindow(
            ISender sender,
            IFormAbstractFactory<LoginWindow> loginFactory,
            IFormAbstractFactory<CreateSecretWindow> createFactory)
        {
            _sender = sender;
            _loginFactory = loginFactory;
            _createFactory = createFactory;
            
            defaultExportFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!Login())
            {
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        private void btnCreateSecrets_Click(object sender, RoutedEventArgs e)
        {
            var createSecretWindow = _createFactory.Create();
            createSecretWindow.ReloadSecrets += ReloadSecrets;
            createSecretWindow.Show();
        }

        private async void btnImport_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;

            var ofd = new OpenFileDialog()
            {
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "Json Files|*.json",
                FilterIndex = 0,
            };

            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
            }

            var result = await _sender.Send(new ImportSecretListCommand("mdgeorgiev@tbibank.bg", filePath));

            if (!result.IsSuccess)
            {
                await ValidateError("Unable to import secrets!");
                return;
            }
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSecrets.Items.Count == 0)
            {
                await ValidateError("No secrets to export!");
                return;
            }

            string directoryPath = string.Empty;

            var ofd = new OpenFolderDialog()
            {
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
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

        private async void ReloadSecrets(object? sender, EventArgs e)
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);
            var secretList = result.Adapt<SecretListViewModel>();

            dataGridSecrets.ItemsSource = secretList.Secrets;
        }


        private async Task ValidateError(string errorMessage, int appearMessageTicks = 2000)
        {
            textBlockValidation.Text = errorMessage;
            await Task.Delay(appearMessageTicks);
            textBlockValidation.Text = string.Empty;
        }
    }
}
