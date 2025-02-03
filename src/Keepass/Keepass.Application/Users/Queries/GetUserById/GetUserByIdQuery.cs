namespace Keepass.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResult>;
    public record GetUserByIdResult(User User);
}
