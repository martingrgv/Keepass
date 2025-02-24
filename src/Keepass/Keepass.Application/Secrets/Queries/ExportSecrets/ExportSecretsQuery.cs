namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public record ExportSecretsQuery(string FilePath) : IQuery<ExportSecretsResult>;
    public record ExportSecretsResult(bool IsSuccess);
}
