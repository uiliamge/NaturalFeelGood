
using FluentValidation;
using NaturalFeelGood.Application.Features.ElementType.Dtos;

namespace NaturalFeelGood.Application.Validators
{
    public class CreateElementTypeDtoValidator : AbstractValidator<CreateElementTypeDto>
    {
        public CreateElementTypeDtoValidator()
        {
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required.");
            RuleFor(x => x.Label.En).NotEmpty().WithMessage("English label is required.");
            RuleFor(x => x.Color).Matches("^#([A-Fa-f0-9]{6})$").WithMessage("Invalid color code.");
            RuleFor(x => x.Order).GreaterThan(0).WithMessage("Order must be greater than 0.");
        }
    }
}
