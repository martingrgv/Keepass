namespace Keepass.Application.Secrets.Commands.DeleteSecret
{
    public class DeleteSecretCommandHandler(ISecretRepository secretRepository, IMediator mediator)
        : ICommandHandler<DeleteSecretCommand, DeleteSecretResult>
    {
        public async Task<DeleteSecretResult> Handle(DeleteSecretCommand command, CancellationToken cancellationToken)
        {
            var secret = await secretRepository.GetSecretAsync(command.Id);

            if (secret is null)
            {
                throw new NotFoundException(command.Id.ToString());
            }

            secretRepository.Delete(secret);
            await secretRepository.SaveChangesAsync();

            await mediator.Publish(new DeleteSecretEvent(secret), cancellationToken);

            return new DeleteSecretResult(true);
        }
    }
}
