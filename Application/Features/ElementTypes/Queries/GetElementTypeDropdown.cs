using Application.Common.Interfaces;
using Application.Features.Common.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace Application.Features.ElementTypes.Queries
{
    /// <summary>
    /// Provides a query to get element type dropdown data.
    /// </summary>
    public static class GetElementTypeDropdown
    {
        public record Query : IRequest<List<DropdownDto>>;

        public class Handler : IRequestHandler<Query, List<DropdownDto>>
        {
            private readonly IElementTypeRepository _repository;
            private readonly ILanguageContext _languageContext;

            public Handler(IElementTypeRepository repository, ILanguageContext languageContext)
            {
                _repository = repository;
                _languageContext = languageContext;
            }

            public async Task<List<DropdownDto>> Handle(GetElementTypeDropdown.Query request, CancellationToken cancellationToken)
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
