namespace Application.Validators.Account
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator(IAccountService accountService)
        {
            RuleFor(c => c.FirstName)
                .MaximumLength(20).WithMessage("Name can not have more letters than 20")
                .NotEmpty().WithMessage("Name can not be empty");

            RuleFor(c => c.LastName)
                .MaximumLength(20).WithMessage("Last name can not have more letters than 20")
                .NotEmpty().WithMessage("Last name can not be empty");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email can not be empty")
                .EmailAddress();

            RuleFor(c => c.Password)
                .MinimumLength(6)
                .NotEmpty().WithMessage("Password can not be empty");

            RuleFor(c => c.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(r => r.Email)
                .Custom((value, context) =>
                {
                    var isEmailIsTaken = accountService.IsMailIsTaken(value).Result;
                    if (isEmailIsTaken)
                        context.AddFailure(nameof(RegisterDto.Email), "That email is taken");
                });
        }
    }
}
