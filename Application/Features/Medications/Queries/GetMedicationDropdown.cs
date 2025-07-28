using Application.Common.Interfaces;
using Application.Features.Common.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.Medications.Queries
{
    /// <summary>
    /// Provides a query to get medcation dropdown data.
    /// </summary>
    public static class GetMedicationDropdown
    {
        public record Query : IRequest<List<BaseDropdownDto>>;

        public class Handler : IRequestHandler<Query, List<BaseDropdownDto>>
        {
            private readonly IMedicationRepository _repository;
            private readonly ILanguageContext _languageContext;

            public Handler(IMedicationRepository repository, ILanguageContext languageContext)
            {
                _repository = repository;
                _languageContext = languageContext;
            }

            public async Task<List<BaseDropdownDto>> Handle(GetMedicationDropdown.Query request, CancellationToken cancellationToken)
            {
                var all = await _repository.GetAllAsync();
                var lang = _languageContext.Language;

                return all.Select(x => new BaseDropdownDto
                {
                    Value = x.Id,
                    Label = $"{x.BrandName.Get(lang)} [{x.GenericName.Get(lang)}]"
                }).OrderBy(x => x.Label).ToList();
            }
        }
    }
}
