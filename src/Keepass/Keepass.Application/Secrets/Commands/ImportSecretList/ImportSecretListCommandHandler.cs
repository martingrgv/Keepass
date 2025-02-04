using Keepass.Application.DTOs;
using Mapster;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Keepass.Application.Secrets.Commands.ImportSecretList
{
    public class ImportSecretListCommandHandler(ISecretRepository secretRepository, ICryptography cryptography)
        : ICommandHandler<ImportSecretListCommand, ImportSecretListResult>
    {
        public async Task<ImportSecretListResult> Handle(ImportSecretListCommand command, CancellationToken cancellationToken)
        {
            string json = File.ReadAllText(command.FilePath);
            var secretDtos = JsonConvert.DeserializeObject<ImportSecretDTO[]>(json);

            foreach (var dto in secretDtos)
            {
                var secret = dto.Adapt<Secret>();
                var entry = await secretRepository.GetSecretAsync(secret.Id);

                if (entry != null)
                {
                    continue;
                }

                byte[] cryptoKeyBefore = cryptography.Key;

                cryptography.SetKey(command.Key);

                try
                {
                    var decryptedPassword = cryptography.Decrypt(secret.Password);

                    cryptography.SetKey(Convert.ToBase64String(cryptoKeyBefore));
                    secret.SetPassword(cryptography.Encrypt(decryptedPassword));

                    await secretRepository.AddAsync(secret);
                }
                catch(CryptographicException)
                {
                    return new ImportSecretListResult(false);
                }
            }

            return new ImportSecretListResult(true);
        }
    }
}
