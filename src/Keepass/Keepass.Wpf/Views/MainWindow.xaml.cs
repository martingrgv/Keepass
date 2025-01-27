using Keepass.Application.Secrets.Queries.GetSecrets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Keepass.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISender _sender;

        public MainWindow(ISender sender)
        {
            InitializeComponent();

            _sender = sender;
        }

        private async void btnReloadSecrets_Click(object sender, RoutedEventArgs e)
        {
            var query = new GetSecretListQuery();
            var result = await _sender.Send(query);

            dataGridSecrets.ItemsSource = result.Secrets;
        }
    }
}
