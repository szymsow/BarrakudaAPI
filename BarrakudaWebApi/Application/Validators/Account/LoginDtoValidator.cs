namespace Application.Validators.Account
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can not be empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password can not be empty");
        }
    }
}
