
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Symptoms.Queries
{
    public record GetAllSymptomsQuery : IRequest<List<Symptom>>;

    public class GetAllSymptomsHandler : IRequestHandler<GetAllSymptomsQuery, List<Symptom>>
    {
        private readonly ISymptomRepository _repository;

        public GetAllSymptomsHandler(ISymptomRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Symptom>> Handle(GetAllSymptomsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
