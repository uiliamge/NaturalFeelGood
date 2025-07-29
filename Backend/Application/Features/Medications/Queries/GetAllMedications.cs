
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Medications.Queries
{
    public record GetAllMedicationsQuery : IRequest<List<Medication>>;

    public class GetAllMedicationsHandler : IRequestHandler<GetAllMedicationsQuery, List<Medication>>
    {
        private readonly IMedicationRepository _repository;

        public GetAllMedicationsHandler(IMedicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Medication>> Handle(GetAllMedicationsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
