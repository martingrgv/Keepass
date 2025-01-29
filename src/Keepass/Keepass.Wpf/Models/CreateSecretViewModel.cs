namespace Keepass.Wpf.Models
{
    public class CreateSecretViewModel
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string Note { get; set; } = default!;
    }
}
