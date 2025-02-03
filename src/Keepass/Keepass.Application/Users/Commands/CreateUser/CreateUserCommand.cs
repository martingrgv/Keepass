namespace Keepass.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Key) : ICommand<CreateUserResult>;
    public record CreateUserResult(User User);
}
