using Application.Common.Interfaces;
using FluentValidation;
using NaturalFeelGood.Application.Features.ElementType.Commands;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.ElementTypes.Validators
{
    public class DeleteElementTypeCommandValidator : AbstractValidator<DeleteElementTypeCommand>
    {
        private readonly INaturalElementRepository _naturalElementRepository;
        private readonly IErrorMessageProvider _errorProvider;
        private readonly ILanguageContext _languageContext;

        public DeleteElementTypeCommandValidator(
            INaturalElementRepository naturalElementRepository,
            IErrorMessageProvider errorProvider,
            ILanguageContext languageContext)
        {
            _naturalElementRepository = naturalElementRepository;
            _errorProvider = errorProvider;
            _languageContext = languageContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_ => _errorProvider.GetMessage("Required", _languageContext.Language))
                .MustAsync(BeNotInUse).WithMessage(_ => _errorProvider.GetMessage("CannotDeleteBecauseInUse", _languageContext.Language));
        }

        private async Task<bool> BeNotInUse(string value, CancellationToken cancellationToken)
        {
            var count = await _naturalElementRepository.CountByElementTypeAsync(value);
            return count == 0;
        }
    }
}
