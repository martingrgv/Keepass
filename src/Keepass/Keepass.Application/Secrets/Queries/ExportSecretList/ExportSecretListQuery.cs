namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public record ExportSecretListQuery(string FilePath) : IQuery<ExportSecretListResult>;
    public record ExportSecretListResult(bool IsSuccess);
}
