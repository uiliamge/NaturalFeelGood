
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("Problem")]
    public class Problem
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public Label Label { get; set; } = new Label();
        public string OrganId { get; set; } = string.Empty;
        public List<string> SymptomsIds { get; set; } = new();
    }
}
