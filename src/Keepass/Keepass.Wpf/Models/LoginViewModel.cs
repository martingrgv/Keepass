namespace Keepass.Wpf.Models
{
    public class LoginViewModel
    {
        public LoginViewModel(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }

        public void SetKey(string key)
        {
            Key = key;
        }
    }
}
