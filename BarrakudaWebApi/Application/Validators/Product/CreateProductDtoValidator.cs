namespace Application.Validators.Product
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(20).WithMessage("Name can not have more letters than 20")
                .NotEmpty().WithMessage("Name can not be empty");

            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("Description can not have more letters than 200")
                .NotEmpty().WithMessage("Description can not be empty");

            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("Quantity is required");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Price is required");
        }
    }
}
