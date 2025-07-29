
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using NaturalFeelGood.Domain.Common;
using Amazon.DynamoDBv2.DataModel;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("Contraindication")]
    public class Contraindication
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
        public Label Label { get; set; } = new Label();
    }
 
}
