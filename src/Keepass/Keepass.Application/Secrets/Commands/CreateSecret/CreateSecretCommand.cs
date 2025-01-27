namespace Keepass.Application.Secrets.Commands.CreateSecret
{
    public record CreateSecretCommand(string Username, string Password, string? Note, string? Url) : ICommand<CreateSecretResult>;
    public record CreateSecretResult(Secret Secret);
}
