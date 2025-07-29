namespace Application.Features.Medications.Dtos
{
    public class CreateMedicationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Form { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
