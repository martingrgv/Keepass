using Domain.Entities;

namespace Application.Data
{
    public class SecretRepository
        : ISecretRepository
    {
        public Task Add(Secret entry)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Secret> GetSecret(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
