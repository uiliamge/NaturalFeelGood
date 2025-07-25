
using MediatR;
using NaturalFeelGood.Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Application.Features.ElementType.Queries
{
    public record GetAllElementTypesQuery : IRequest<List<Domain.Entities.ElementType>>;

    public class GetAllElementTypesHandler : IRequestHandler<GetAllElementTypesQuery, List<Domain.Entities.ElementType>>
    {
        private readonly IElementTypeRepository _repository;

        public GetAllElementTypesHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.ElementType>> Handle(GetAllElementTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
