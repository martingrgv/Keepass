
namespace Keepass.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository)
        : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(
                Guid.NewGuid(),
                command.Key);

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            return new CreateUserResult(user);
        }
    }
}
