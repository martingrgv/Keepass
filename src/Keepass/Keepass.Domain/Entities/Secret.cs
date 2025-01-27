using Keepass.Domain.Contracts;

namespace Keepass.Domain.Entities
{
    public class Secret : IEntity
    {
        public Secret()
        {
            // Empty constructor requirement for EFCore   
        }

        public Secret(Guid id, string username, string password, string? note, string? url)
        {
            Id = id;
            Username = username;
            Password = password;
            Note = note;
            Url = url;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string? Note { get; private set; } = default!;
        public string? Url { get; private set; }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetNote(string note)
        {
            Note = note;
        }

        public void SetUrl(string url)
        {
            Url = url;
        }
    }
}
