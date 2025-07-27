using Amazon.DynamoDBv2.DataModel;

namespace Domain.Entities
{
    [DynamoDBTable("NaturalElementXProblem")]
    public class NaturalElementXProblem
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = default!;

        public string NaturalElementId { get; set; } = default!;
        public string ProblemId { get; set; } = default!;
    }
}