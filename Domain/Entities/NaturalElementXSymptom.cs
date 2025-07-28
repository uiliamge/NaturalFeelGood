using Amazon.DynamoDBv2.DataModel;

namespace Domain.Entities
{
    [DynamoDBTable("NaturalElementXSymptom")]
    public class NaturalElementXSymptom
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = default!;

        public string NaturalElementId { get; set; } = default!;
        public string SymptomId { get; set; } = default!;
    }
}
