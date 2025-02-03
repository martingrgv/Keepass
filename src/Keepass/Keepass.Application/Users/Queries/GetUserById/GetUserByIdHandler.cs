
namespace Keepass.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler(IUserRepository userRepository)
        : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
    {
        public async Task<GetUserByIdResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserAsync(query.Id);

            if (user is null)
            {
                throw new NotFoundException(query.Id.ToString());
            }

            return new GetUserByIdResult(user);
        }
    }
}
