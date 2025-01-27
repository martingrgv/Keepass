
namespace Keepass.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CreateSecretWindow.xaml
    /// </summary>
    public partial class CreateSecretWindow : Window
    {
        private readonly ISender _sender;

        public CreateSecretWindow(ISender sender)
        {
            _sender = sender;

            InitializeComponent();
        }
    }
}
