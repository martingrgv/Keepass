namespace Keepass.Domain.Entities
{
    public class User
    {
        public User()
        {
            // Empty constructor requirement for EFCore   
        }

        public User(Guid id, string key)
        {
            Id = id;
            Key = key;
        }

        public Guid Id { get; private set; } = default!;
        public string Key { get; private set; } = default!;
    }
}
