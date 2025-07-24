
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("Organ")]
    public class Organ
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public string BodySystemCategoryId { get; set; }
        public Label Label { get; set; } = new Label();
        public string Image { get; set; } = string.Empty;
        public List<string> Problems { get; set; } = new();
    }
}
