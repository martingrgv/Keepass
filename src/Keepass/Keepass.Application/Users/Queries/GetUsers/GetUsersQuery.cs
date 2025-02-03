namespace Keepass.Application.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IQuery<GetUsersQueryResult>;
    public record GetUsersQueryResult(ICollection<User> Users);
}
