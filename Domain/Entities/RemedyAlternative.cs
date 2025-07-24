
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Domain.Entities
{
    [DynamoDBTable("RemedyAlternative")]
    public class RemedyAlternative
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
        public Label Label { get; set; } = new Label();
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> RelatedMedications { get; set; } = new();
        public List<string> RelatedProblems { get; set; } = new();
        public List<string> RelatedSymptoms { get; set; } = new();
        public List<string> ContraindicationTypes { get; set; } = new();
    }
}
