namespace Keepass.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key cannot be null");
        }
    }
}
