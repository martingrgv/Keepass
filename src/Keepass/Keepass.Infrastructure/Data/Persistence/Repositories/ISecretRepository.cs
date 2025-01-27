using Keepass.Domain.Entities;

namespace Keepass.Infrastructure.Data.Persistence.Repositories
{
    public interface ISecretRepository
    {
        public Task<IEnumerable<Secret>> SecretsAsync();
        public Task AddAsync(Secret entry);
        public Task<Secret> GetSecretAsync(Guid id);
        public Task DeleteAsync(Guid id);
    }
}
