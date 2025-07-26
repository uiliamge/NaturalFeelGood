using Amazon.DynamoDBv2.DataModel;

namespace Domain.Entities
{
    [DynamoDBTable("MedicationXRemedyAlternative")]
    public class MedicationXRemedyAlternative
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = default!;

        public string MedicationId { get; set; } = default!;
        public string NaturalElementId { get; set; } = default!;
    }
}
