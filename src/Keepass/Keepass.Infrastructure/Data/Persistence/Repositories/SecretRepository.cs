namespace Keepass.Infrastructure.Data.Persistence.Repositories
{
    public class SecretRepository(KeepassDbContext context)
        : ISecretRepository
    {
        public async Task<Secret?> GetSecretAsync(Guid id)
        {
            return await context.Secrets.FindAsync(id);
        }

        public async Task<IEnumerable<Secret>> SecretsAsync()
        {
            return await context.Secrets.ToListAsync();
        }

        public async Task<IEnumerable<Secret>> SecretsReadOnlyAsync()
        {
            return await context.Secrets.AsNoTracking().ToListAsync();
        }

        public void Add(Secret entry)
        {
            context.Secrets.Add(entry);
        }

        public void AddRange(List<Secret> secrets)
        {
            context.Secrets.AddRange(secrets);
        }

        public void Delete(Secret secret)
        {
            context.Secrets.Remove(secret);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
