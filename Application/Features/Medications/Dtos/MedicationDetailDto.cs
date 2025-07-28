using Application.Features.Problem.Dtos;
using Application.Features.NaturalElement.Dtos;

namespace Application.Features.Medications.Dtos
{
    public class MedicationDetailDto
    {
        public string Id { get; set; } = default!;
        public string BrandName { get; set; } = default!;
        public string GenericName { get; set; } = default!;
        public List<ProblemDto> UsedFor { get; set; } = new();
        public List<NaturalElementSimpleDto> ReplacedBy { get; set; } = new();
    }
}
