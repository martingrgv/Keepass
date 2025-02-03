namespace Keepass.Application.Users.Commands.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("User Id cannot be null");
        }
    }
}
