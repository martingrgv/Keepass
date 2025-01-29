
using Keepass.Application.Secrets.Commands.CreateSecret;

namespace Keepass.Wpf.Views
{
    public partial class CreateSecretWindow : Window
    {
        private readonly ISender _sender;

        public event EventHandler ReloadSecrets = null!;

        public CreateSecretWindow(ISender sender)
        {
            _sender = sender;

            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var command = new CreateSecretCommand(textBoxUsername.Text, textBoxPassword.Text, textBoxNote.Text, textBoxUrl.Text);
            var result = await _sender.Send(command);

            ReloadSecrets?.Invoke(this, EventArgs.Empty);

            Close();
        }
    }
}
