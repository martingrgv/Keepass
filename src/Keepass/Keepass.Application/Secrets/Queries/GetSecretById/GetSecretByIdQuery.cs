namespace Keepass.Application.Secrets.Queries.GetSecretById
{
    public record GetSecretByIdQuery(Guid Id) : IQuery<GetSecretByIdResult>;
    public record GetSecretByIdResult(Secret secret);
}
