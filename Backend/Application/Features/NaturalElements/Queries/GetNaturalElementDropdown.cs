using Application.Common.Interfaces;
using Application.Features.Common.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.NaturalElements.Queries
{
    /// <summary>
    /// Provides a query to get natural element dropdown data.
    /// </summary>
    public static class GetNaturalElementDropdown
    {
        public record Query : IRequest<List<BaseDropdownDto>>;

        public class Handler : IRequestHandler<Query, List<BaseDropdownDto>>
        {
            private readonly INaturalElementRepository _repository;
            private readonly ILanguageContext _languageContext;

            public Handler(INaturalElementRepository repository, ILanguageContext languageContext)
            {
                _repository = repository;
                _languageContext = languageContext;
            }

            public async Task<List<BaseDropdownDto>> Handle(GetNaturalElementDropdown.Query request, CancellationToken cancellationToken)
            {
                var all = await _repository.GetAllAsync(cancellationToken);
                var lang = _languageContext.Language;

                return all.Select(x => new BaseDropdownDto
                {
                    Value = x.Id,
                    Label = x.Label.Get(lang)
                }).OrderBy(x => x.Label).ToList();
            }
        }
    }
}
