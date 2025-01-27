
namespace Keepass.Application.Contracts
{
    public interface ISecretRepository
    {
        public Task<IEnumerable<Secret>> SecretListAsync();
        public Task<IEnumerable<Secret>> SecretListReadOnlyAsync();
        public Task AddAsync(Secret entry);
        public Task<Secret?> GetSecretAsync(Guid id);
        public Task DeleteAsync(Secret secret);
    }
}
