using Newtonsoft.Json;

namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public class ExportSecretsQueryHandler(ISecretRepository secretRepository, ICryptography cryptography)
        : IQueryHandler<ExportSecretsQuery, ExportSecretsResult>
    {
        public async Task<ExportSecretsResult> Handle(ExportSecretsQuery query, CancellationToken cancellationToken)
        {
            var secretDtos = new List<SecretDto>();
            var secrets = await secretRepository.SecretsAsync();

            foreach (var secret in secrets)
            {
                var decryptedPassword = cryptography.Decrypt(secret.Password);
                var secretDto = new SecretDto(secret.Username, decryptedPassword, secret.Url, secret.Note);

                secretDtos.Add(secretDto);
            }

            await WriteFile(query.FilePath, secretDtos);

            return new ExportSecretsResult(true);
        }

        private async Task WriteFile(string filePath, List<SecretDto> secretDtos)
        {
            var json = JsonConvert.SerializeObject(secretDtos, Formatting.Indented);

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    await sw.WriteAsync(json);
                }
            }
        }
    }
}
