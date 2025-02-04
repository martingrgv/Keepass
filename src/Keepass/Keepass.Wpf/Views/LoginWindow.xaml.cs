using Keepass.Application.Contracts;
using Keepass.Application.Users.Commands.CreateUser;
using Keepass.Application.Users.Queries.GetUsers;
using Keepass.Wpf.Validators;
using System.Security.Cryptography;
using System.Text;

namespace Keepass.Wpf
{
    public partial class LoginWindow : Window
    {
        private readonly ICryptography _cryptography;
        private readonly IMediator _mediator;
        private LoginViewModel _loginModel;

        public LoginWindow(ICryptography cryptography, IMediator medaitor)
        {
            _cryptography = cryptography;
            _mediator = medaitor;
            _loginModel = new(string.Empty);

            InitializeComponent();
        }

        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!await IsLoginValid())
            {
                validationMessage.Text = "Invalid key";
                return;
            }

            _cryptography.SetKey(_loginModel.Key);

            DialogResult = true;
            Close();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidateModel();
        }

        private Task<bool> ValidateModel()
        {
            validationMessage.Text = string.Empty;

            _loginModel.SetKey(passwordBox.Password);

            var validator = new LoginValidator();
            var validationResults = validator.Validate(_loginModel);

            if (!validationResults.IsValid)
            {
                string error = validationResults.Errors.FirstOrDefault()?.ErrorMessage!;
                validationMessage.Text = error;

                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        private async Task<bool> IsLoginValid()
        {
            if(!await ValidateModel())
            {
                return false;
            }

            var usersResult = await _mediator.Send(new GetUsersQuery());

            var sha256 = SHA256.Create();
            byte[] keyBytes = Encoding.UTF8.GetBytes(_loginModel.Key);
            byte[] encodedKey = sha256.ComputeHash(keyBytes);
            string key = Convert.ToBase64String(encodedKey);

            if (usersResult.Users.Count == 0)
            {
                var command = new CreateUserCommand(key);
                await _mediator.Send(command);

                return true;
            }
            else
            {
                var user = usersResult.Users.FirstOrDefault()!;

                if (user.Key == key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
