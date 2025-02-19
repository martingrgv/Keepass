using Newtonsoft.Json;

namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public class ExportSecretListQueryHandler(ISecretRepository secretRepository, ICryptography cryptography)
        : IQueryHandler<ExportSecretListQuery, ExportSecretListResult>
    {
        public async Task<ExportSecretListResult> Handle(ExportSecretListQuery query, CancellationToken cancellationToken)
        {
            var secretDtos = new List<ExportSecretDTO>();
            var secrets = await secretRepository.SecretListAsync();

            foreach (var secret in secrets)
            {
                var decryptedPassword = cryptography.Decrypt(secret.Password);
                var secretDto = new ExportSecretDTO(secret.Username, decryptedPassword, secret.Url, secret.Note);

                secretDtos.Add(secretDto);
            }

            var json = JsonConvert.SerializeObject(secretDtos, Formatting.Indented);

            using (var fs = new FileStream(query.FilePath, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(json);
                }
            } 
            return new ExportSecretListResult(true);
        }
    }
}
