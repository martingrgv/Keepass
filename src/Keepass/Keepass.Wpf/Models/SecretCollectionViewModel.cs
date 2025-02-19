using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Keepass.Wpf.Models
{
    public class SecretCollectionViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SecretViewModel> _secrets = new();

        public ObservableCollection<SecretViewModel> Secrets
        {
            get => _secrets;
            set
            {
                _secrets = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
