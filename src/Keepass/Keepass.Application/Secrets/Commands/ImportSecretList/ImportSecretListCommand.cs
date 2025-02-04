namespace Keepass.Application.Secrets.Commands.ImportSecretList
{
    public record ImportSecretListCommand(string Key, string FilePath) : ICommand<ImportSecretListResult>;
    public record ImportSecretListResult(bool IsSuccess);
}
