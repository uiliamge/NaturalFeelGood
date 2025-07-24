
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("ContraindicationType")]
    public class ContraindicationType
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public Label Label { get; set; } = new Label();
        public string Icon { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
