using Keepass.Application.Contracts;
using Keepass.Wpf.Validators;
using System.Security.Cryptography;

namespace Keepass.Wpf
{
    public partial class LoginWindow : Window
    {
        private readonly ICryptography _cryptography;
        private LoginViewModel _loginModel;

        public LoginWindow(ISecretRepository secretRepository, ICryptography cryptography)
        {
            _cryptography = cryptography;
            _loginModel = new(string.Empty);

            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoginValid())
            {
                _cryptography.SetKey(_loginModel.Key);
                Close();
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            IsLoginValid();
        }

        private bool IsLoginValid()
        {
            _loginModel.SetKey(passwordBox.Password);

            var validator = new LoginValidator();
            var validationResults = validator.Validate(_loginModel);

            if (!validationResults.IsValid)
            {
                string error = validationResults.Errors.FirstOrDefault()?.ErrorMessage!;
                validationMessage.Text = error;

                return false;
            }

            validationMessage.Text = string.Empty;
            return true;
        }
    }
}
