namespace Keepass.Application.Secrets.Queries.GetSecrets
{
    public class GetSecretListQueryHandler(ISecretRepository secretRepository, ICryptography cryptography)
        : IQueryHandler<GetSecretListQuery, GetSecretListQueryResult>
    {
        public async Task<GetSecretListQueryResult> Handle(GetSecretListQuery query, CancellationToken cancellationToken)
        {
            var secrets = await secretRepository.SecretListReadOnlyAsync();
            
            foreach (var secret in secrets)
            {
                secret.SetPassword(cryptography.Decrypt(secret.Password));
            }

            return new GetSecretListQueryResult(secrets);
        }
    }
}
