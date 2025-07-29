using Application.Features.Medications.Dtos;
using MediatR;

namespace NaturalFeelGood.Application.Features.Medications.Queries
{
    public class GetMedicationByNameQuery : IRequest<MedicationDetailDto>
    {
        public string Name { get; set; }
        public GetMedicationByNameQuery(string name) => Name = name;
    }
}
