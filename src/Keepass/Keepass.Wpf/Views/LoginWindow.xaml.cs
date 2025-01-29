using Keepass.Application.Contracts;

namespace Keepass.Wpf
{
    public partial class LoginWindow : Window
    {
        private readonly ICryptography _cryptography;
        public LoginWindow(ISecretRepository secretRepository, ICryptography cryptography)
        {
            _cryptography = cryptography;

            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string key = passwordBoxKey.Password;
            _cryptography.SetKey(key);

            Close();
        }
    }
}
