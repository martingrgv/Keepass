namespace Keepass.Infrastructure.Data.Persistence.Repositories
{
    public class SecretRepository(KeepassDbContext context)
        : ISecretRepository
    {
        public async Task AddAsync(Secret entry)
        {
            context.Secrets.Add(entry);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Secret secret)
        {
            context.Secrets.Remove(secret);
            await context.SaveChangesAsync();
        }

        public async Task<Secret?> GetSecretAsync(Guid id)
        {
            var secret = await context.Secrets.FindAsync(id);

            return secret;
        }

        public async Task<IEnumerable<Secret>> SecretListAsync()
        {
            return await context.Secrets.ToListAsync();
        }

        public async Task<IEnumerable<Secret>> SecretListReadOnlyAsync()
        {
            return await context.Secrets.AsNoTracking().ToListAsync();
        }
    }
}
