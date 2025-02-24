
namespace Keepass.Application.Contracts
{
    public interface ISecretRepository
    {
        public Task<IEnumerable<Secret>> SecretsAsync();
        public Task<IEnumerable<Secret>> SecretsReadOnlyAsync();
        public Task<Secret?> GetSecretAsync(Guid id);
        public void Add(Secret entry);
        public void AddRange(List<Secret> secrets);
        public void Delete(Secret secret);
        public Task SaveChangesAsync();
    }
}
