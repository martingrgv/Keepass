namespace Keepass.Application.Secrets.Queries.ExportSecretList
{
    public record ExportSecretDTO(string Username, string Password, string? Url, string? Note);
}
