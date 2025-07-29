using Application.Common.Interfaces;
using Application.Features.Common.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.Organs.Queries
{
    /// <summary>
    /// Provides a query to get organ dropdown data.
    /// </summary>
    public static class GetOrganDropdown
    {
        public record Query : IRequest<List<BaseDropdownDto>>;

        public class Handler : IRequestHandler<Query, List<BaseDropdownDto>>
        {
            private readonly IOrganRepository _repository;
            private readonly ILanguageContext _languageContext;

            public Handler(IOrganRepository repository, ILanguageContext languageContext)
            {
                _repository = repository;
                _languageContext = languageContext;
            }

            public async Task<List<BaseDropdownDto>> Handle(Query request, CancellationToken cancellationToken)
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
