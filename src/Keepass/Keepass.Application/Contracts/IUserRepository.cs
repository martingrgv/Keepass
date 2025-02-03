namespace Keepass.Application.Contracts
{
    public interface IUserRepository
    {
        Task<ICollection<User>> AllUsersReadOnly();
        Task<User?> GetUserAsync(Guid id);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task SaveChangesAsync();
    }
}
