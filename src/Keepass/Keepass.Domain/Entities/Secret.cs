using Keepass.Domain.Contracts;

namespace Keepass.Domain.Entities
{
    public class Secret : IEntity
    {
        public Secret()
        {
            // Empty constructor requirement for EFCore   
        }

        public Secret(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string? Notes { get; private set; } = default!;
        public string? Url { get; private set; }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetDescription(string description)
        {
            Notes = description;
        }

        public void SetUrl(string url)
        {
            Url = url;
        }
    }
}
