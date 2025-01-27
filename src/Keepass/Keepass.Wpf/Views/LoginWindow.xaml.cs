using Keepass.Application.Contracts;

namespace Keepass.Wpf
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(ISecretRepository secretRepository, ICryptography cryptography)
        {
            InitializeComponent();
        }
    }
}
