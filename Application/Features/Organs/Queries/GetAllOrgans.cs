
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Organs.Queries
{
    public record GetAllOrgansQuery : IRequest<List<Organ>>;

    public class GetAllOrgansHandler : IRequestHandler<GetAllOrgansQuery, List<Organ>>
    {
        private readonly IOrganRepository _repository;

        public GetAllOrgansHandler(IOrganRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Organ>> Handle(GetAllOrgansQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
