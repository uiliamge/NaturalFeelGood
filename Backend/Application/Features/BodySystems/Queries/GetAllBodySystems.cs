
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.BodySystems.Queries
{
    public record GetAllBodySystemsQuery : IRequest<List<BodySystem>>;

    public class GetAllBodySystemsHandler : IRequestHandler<GetAllBodySystemsQuery, List<BodySystem>>
    {
        private readonly IBodySystemRepository _repository;

        public GetAllBodySystemsHandler(IBodySystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BodySystem>> Handle(GetAllBodySystemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
