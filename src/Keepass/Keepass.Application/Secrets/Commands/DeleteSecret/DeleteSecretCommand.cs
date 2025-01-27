namespace Keepass.Application.Secrets.Commands.DeleteSecret
{
    public record DeleteSecretCommand(Guid Id) : ICommand<DeleteSecretResult>;
    public record DeleteSecretResult(bool IsSuccess);
}
