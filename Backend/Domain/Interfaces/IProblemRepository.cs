using Amazon.DynamoDBv2.Model;
using Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Domain.Interfaces
{
    public interface IProblemRepository : IRepository<HealthProblem>
    {
        Task<(List<HealthProblem> Items, Dictionary<string, AttributeValue>? LastKey)> GetPaginatedAsync(int pageSize, Dictionary<string, AttributeValue>? lastKey, CancellationToken cancellationToken);
    }
}
