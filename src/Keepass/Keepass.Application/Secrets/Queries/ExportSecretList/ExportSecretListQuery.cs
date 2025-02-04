namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public record ExportSecretListQuery() : IQuery<ExportSecretListResult>;
    public record ExportSecretListResult(byte[] FileBytes);
}
