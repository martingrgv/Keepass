
namespace Keepass.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository userRepository)
        : ICommandHandler<DeleteUserCommand, DeleteUserResult>
    {
        public async Task<DeleteUserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserAsync(command.Id);

            if (user != null)
            {
                await userRepository.DeleteAsync(user);
                await userRepository.SaveChangesAsync();
            }

            return new DeleteUserResult();
        }
    }
}
