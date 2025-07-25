// Application/Features/Medications/Queries/GetMedicationByNameQuery.cs

using MediatR;
using NaturalFeelGood.Application.Features.Medications.Dtos;

namespace NaturalFeelGood.Application.Features.Medications.Queries
{
    public class GetMedicationByNameQuery : IRequest<MedicationDetailDto>
    {
        public string Name { get; set; }
        public GetMedicationByNameQuery(string name) => Name = name;
    }
}
