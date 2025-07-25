using Application.Features.Organ;
using Application.Features.Symptom.Dtos;

namespace Application.Features.Problem.Dtos
{
    public class ProblemDto
    {
        public string Id { get; set; } = default!;
        public string Label { get; set; } = default!;
        public OrganDto Organ { get; set; } = default!;
        public List<SymptomDto> Symptoms { get; set; } = new();
    }
}
