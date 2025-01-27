namespace Keepass.Application.Secrets.Commands.DeleteSecret
{
    public class DeleteSecretCommandHandler(ISecretRepository secretRepository)
        : ICommandHandler<DeleteSecretCommand, DeleteSecretResult>
    {
        public async Task<DeleteSecretResult> Handle(DeleteSecretCommand command, CancellationToken cancellationToken)
        {
            var secret = await secretRepository.GetSecretAsync(command.Id);

            if (secret is null)
            {
                throw new NotFoundException(command.Id.ToString());
            }

            await secretRepository.DeleteAsync(secret);

            return new DeleteSecretResult(true);
        }
    }
}
