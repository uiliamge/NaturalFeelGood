
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("Medication")]
    public class Medication
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public Label BrandName { get; set; } = new Label();
        public Label GenericName { get; set; } = new Label();
        public List<string> Problems { get; set; }
    }
}
