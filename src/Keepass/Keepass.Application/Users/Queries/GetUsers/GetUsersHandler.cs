namespace Keepass.Application.Users.Queries.GetUsers
{
    public class GetUsersHandler(IUserRepository userRepository)
        : IQueryHandler<GetUsersQuery, GetUsersQueryResult>
    {
        public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.AllUsersReadOnly();
            return new GetUsersQueryResult(users);
        }
    }
}
