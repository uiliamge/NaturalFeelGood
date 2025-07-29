
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("BodySystem")]
    public class BodySystem
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public Label Label { get; set; } = new Label();
        public int Order { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
