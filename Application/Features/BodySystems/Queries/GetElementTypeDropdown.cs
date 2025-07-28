using Application.Common.Interfaces;
using Application.Features.Common.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.BodySystems.Queries
{
    /// <summary>
    /// Provides a query to get body system dropdown data.
    /// </summary>
    public static class GetBodySystemDropdown
    {
        public record Query : IRequest<List<DropdownDto>>;

        public class Handler : IRequestHandler<Query, List<DropdownDto>>
        {
            private readonly IBodySystemRepository _repository;
            private readonly ILanguageContext _languageContext;

            public Handler(IBodySystemRepository repository, ILanguageContext languageContext)
            {
                _repository = repository;
                _languageContext = languageContext;
            }

            public async Task<List<DropdownDto>> Handle(GetBodySystemDropdown.Query request, CancellationToken cancellationToken)
            {
                var all = await _repository.GetAllAsync();
                var lang = _languageContext.Language;

                return all.Select(x => new DropdownDto
                {
                    Value = x.Id,
                    Label = x.Label.Get(lang),
                    Icon = x.Icon,
                    Color = x.Color
                }).OrderBy(x => x.Label).ToList();
            }
        }
    }
}
