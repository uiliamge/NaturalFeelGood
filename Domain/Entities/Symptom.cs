
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("Symptom")]
    public class Symptom
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public string OrganId { get; set; }
        public Label Label { get; set; } = new Label();
    }
}
