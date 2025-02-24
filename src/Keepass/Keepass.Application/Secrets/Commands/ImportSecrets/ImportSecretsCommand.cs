namespace Keepass.Application.Secrets.Commands.ImportSecrets
{
    public record ImportSecretsCommand(string FilePath) : ICommand<ImportSecretsResult>;
    public record ImportSecretsResult(bool IsSuccess);
}
