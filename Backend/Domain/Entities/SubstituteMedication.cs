using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("SubstituteMedication")]
    public class SubstituteMedication
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;
        public string GenericName { get; set; } = string.Empty;
        public Label Comparison { get; set; } = new Label();
    }
}
