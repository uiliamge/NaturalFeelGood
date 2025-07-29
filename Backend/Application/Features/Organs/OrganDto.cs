using Application.Features.BodySystem.Dtos;

namespace Application.Features.Organ
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an Organ.
    /// </summary>
    public class OrganDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the organ.
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Gets or sets the label or name of the organ.
        /// </summary>
        public string Label { get; set; } = default!;

        /// <summary>
        /// Gets or sets the associated body system of the organ.
        /// </summary>
        public BodySystemDto? BodySystem { get; set; } = default!;
    }
}
