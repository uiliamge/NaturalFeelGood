
using MediatR;
using NaturalFeelGood.Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Application.Features.ElementTypes.Queries
{
    public record GetAllElementTypesQuery : IRequest<List<ElementType>>;

    public class GetAllElementTypesHandler : IRequestHandler<GetAllElementTypesQuery, List<ElementType>>
    {
        private readonly IElementTypeRepository _repository;

        public GetAllElementTypesHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ElementType>> Handle(GetAllElementTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
