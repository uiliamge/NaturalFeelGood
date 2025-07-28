
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.NaturalElements.Queries
{
    public record GetAllNaturalElementsQuery : IRequest<List<NaturalElement>>;

    public class GetAllNaturalElementsHandler : IRequestHandler<GetAllNaturalElementsQuery, List<NaturalElement>>
    {
        private readonly INaturalElementRepository _repository;

        public GetAllNaturalElementsHandler(INaturalElementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NaturalElement>> Handle(GetAllNaturalElementsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
