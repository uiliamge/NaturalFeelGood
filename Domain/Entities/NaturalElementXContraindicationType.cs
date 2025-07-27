using Amazon.DynamoDBv2.DataModel;

namespace Domain.Entities
{
    [DynamoDBTable("NaturalElementXContraindicationType")]
    public class NaturalElementXContraindicationType
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = default!;

        public string NaturalElementId { get; set; } = default!;
        public string ContraindicationTypeId { get; set; } = default!;
    }
}
