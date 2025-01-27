namespace Keepass.Application.Secrets.Commands.CreateSecret
{
    public class CreateSecretCommandHandler(ISecretRepository secretRepository, ICryptography cryptography) 
        : ICommandHandler<CreateSecretCommand, CreateSecretResult>
    {
        public async Task<CreateSecretResult> Handle(CreateSecretCommand command, CancellationToken cancellationToken)
        {
            string encryptedPassword = cryptography.Encrypt(command.Password);

            var secret = new Secret(
                Guid.NewGuid(),
                command.Username,
                command.Password,
                command.Note,
                command.Url);

            await secretRepository.AddAsync(secret);

            return new CreateSecretResult(secret);
        }
    }
}
