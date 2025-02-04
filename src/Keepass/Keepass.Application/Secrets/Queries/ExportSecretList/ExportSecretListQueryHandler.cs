
using Newtonsoft.Json;

namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public class ExportSecretListQueryHandler(ISecretRepository secretRepository)
        : IQueryHandler<ExportSecretListQuery, ExportSecretListResult>
    {
        public async Task<ExportSecretListResult> Handle(ExportSecretListQuery query, CancellationToken cancellationToken)
        {
            var secrets = await secretRepository.SecretListAsync();

            var json = JsonConvert.SerializeObject(secrets, Formatting.Indented);

            byte[] fileBytes;

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(json);
                }

                fileBytes = ms.ToArray();
            }

            return new ExportSecretListResult(fileBytes);
        }
    }
}
