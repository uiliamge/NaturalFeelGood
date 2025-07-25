using Application.Features.BodySystem.Dtos;

namespace Application.Features.Organ
{
    public class OrganDto
    {
        public string Id { get; set; } = default!;
        public string Label { get; set; } = default!;
        public BodySystemDto Category { get; set; } = default!;
    }
}
