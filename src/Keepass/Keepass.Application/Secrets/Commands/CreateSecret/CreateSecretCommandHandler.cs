namespace Keepass.Application.Secrets.Commands.CreateSecret
{
    public class CreateSecretCommandHandler(ISecretRepository secretRepository, ICryptography cryptography, IMediator mediator)
        : ICommandHandler<CreateSecretCommand, CreateSecretResult>
    {
        public async Task<CreateSecretResult> Handle(CreateSecretCommand command, CancellationToken cancellationToken)
        {
            string encryptedPassword = cryptography.Encrypt(command.Password);

            var secret = new Secret(
                Guid.NewGuid(),
                command.Username,
                encryptedPassword,
                command.Note,
                command.Url);

            secretRepository.Add(secret);
            await secretRepository.SaveChangesAsync();

            await mediator.Publish(new CreateSecretEvent(secret), cancellationToken);

            return new CreateSecretResult(secret);
        }
    }
}
