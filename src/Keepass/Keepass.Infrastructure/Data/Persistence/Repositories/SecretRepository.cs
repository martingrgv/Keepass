using Keepass.Domain.Entities;
using Keepass.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Keepass.Infrastructure.Data.Persistence.Repositories
{
    public class SecretRepository(KeepassDbContext context)
        : ISecretRepository
    {
        public async Task<IEnumerable<Secret>> SecretsAsync()
        {
            return await context.Secrets.ToListAsync();
        }

        public async Task AddAsync(Secret entry)
        {
            context.Secrets.Add(entry);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var secret = await GetSecretAsync(id);

            context.Secrets.Remove(secret);
            await context.SaveChangesAsync();
        }

        public async Task<Secret> GetSecretAsync(Guid id)
        {
            var secret = await context.Secrets.FindAsync(id);

            if (secret is null)
            {
                throw new NotFoundException(nameof(secret));
            }

            return secret;
        }
    }
}
