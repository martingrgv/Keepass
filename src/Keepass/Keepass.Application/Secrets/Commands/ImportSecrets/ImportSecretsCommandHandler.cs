
using Newtonsoft.Json;

namespace Keepass.Application.Secrets.Commands.ImportSecrets
{
    public class ImportSecretsCommandHandler(ISecretRepository secretRepository, ICryptography cryptography, IMediator mediator)
        : ICommandHandler<ImportSecretsCommand, ImportSecretsResult>
    {
        public async Task<ImportSecretsResult> Handle(ImportSecretsCommand command, CancellationToken cancellationToken)
        {
            var secretDtos = await GetSecretDtos(command.FilePath);

            if (secretDtos is null || secretDtos.Count == 0)
            {
                throw new InvalidOperationException("No secrets to import");
            }

            var secrets = new List<Secret>();

            foreach (var secretDto in secretDtos)
            {
                var encryptedPassword = cryptography.Encrypt(secretDto.Password);
                var secret = new Secret(
                    Guid.NewGuid(),
                    secretDto.Username,
                    encryptedPassword,
                    secretDto.Note,
                    secretDto.Url);

                secrets.Add(secret);
            }

            secretRepository.AddRange(secrets);
            await secretRepository.SaveChangesAsync();

            await mediator.Publish(new UpdateSecretsEvent(secrets));

            return new ImportSecretsResult(true);
        }

        private async Task<List<SecretDto>?> GetSecretDtos(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string json;
                using (var sr = new StreamReader(fs))
                {
                    json = await sr.ReadToEndAsync();
                }

                return JsonConvert.DeserializeObject<List<SecretDto>>(json);
            }
        }
    }
}
