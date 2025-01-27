namespace Keepass.Application.Secrets.Queries.GetSecrets
{
    public record GetSecretListQuery() : IQuery<GetSecretListQueryResult>;
    public record GetSecretListQueryResult(IEnumerable<Secret> Secrets);
}
