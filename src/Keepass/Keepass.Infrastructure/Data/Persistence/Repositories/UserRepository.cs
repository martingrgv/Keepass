namespace Keepass.Infrastructure.Data.Persistence.Repositories
{
    public class UserRepository(KeepassDbContext context)
        : IUserRepository
    {
        public async Task<ICollection<User>> AllUsersReadOnly()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await context.AddAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            context.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            return user ?? null;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
