using Domain.Entities;

namespace Application.Data
{
    public interface ISecretRepository
    {
        public Task Add(Secret entry);
        public Task<Secret> GetSecret(Guid id);
        public Task Delete(Guid id);
    }
}
