using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;
using System.Text.Json;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _client;
        private const string TableName = "HealthProblem";

        public ProblemRepository(IDynamoDBContext context, IAmazonDynamoDB client)
        {
            _context = context;
            _client = client;
        }

        public async Task<List<HealthProblem>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<HealthProblem>(conditions).GetRemainingAsync(cancellationToken);
        }

        // return paginated results
        public async Task<(List<HealthProblem> Items, Dictionary<string, AttributeValue>? LastKey)>
            GetPaginatedAsync(int pageSize, Dictionary<string, AttributeValue>? lastKey, CancellationToken cancellationToken)
        {
            var request = new ScanRequest
            {
                TableName = TableName,
                Limit = pageSize,
                ExclusiveStartKey = lastKey
            };

            var response = await _client.ScanAsync(request, cancellationToken);

            var items = response.Items.Select(item =>
            {
                var json = JsonSerializer.Serialize(item.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.S ?? kvp.Value.N ?? kvp.Value.BOOL.ToString() ?? string.Empty
                ));
                return JsonSerializer.Deserialize<HealthProblem>(json)!;
            }).ToList();

            return (items, response.LastEvaluatedKey);
        }

        // 🔹 Filtro simples (exemplo por organId e medicationId)
        public async Task<List<HealthProblem>> GetAsync(string? organId, string? medicationId, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();

            if (!string.IsNullOrEmpty(organId))
                conditions.Add(new ScanCondition("OrganId", ScanOperator.Equal, organId));

            if (!string.IsNullOrEmpty(medicationId))
                conditions.Add(new ScanCondition("MedicationId", ScanOperator.Equal, medicationId));

            return await _context.ScanAsync<HealthProblem>(conditions).GetRemainingAsync(cancellationToken);
        }

        // 🔹 Busca por ID
        public async Task<HealthProblem?> GetByIdAsync(string value, CancellationToken cancellationToken)
        {
            return await _context.LoadAsync<HealthProblem>(value, cancellationToken);
        }

        // 🔹 Inserção
        public async Task InsertAsync(HealthProblem entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        // 🔹 Atualização
        public async Task UpdateAsync(string value, HealthProblem updated, CancellationToken cancellationToken)
        {
            var existing = await GetByIdAsync(value, cancellationToken);
            if (existing != null)
            {
                updated.Id = existing.Id;
                await _context.SaveAsync(updated, cancellationToken);
            }
        }

        // 🔹 Exclusão
        public async Task DeleteAsync(string value, CancellationToken cancellationToken)
        {
            var existing = await GetByIdAsync(value, cancellationToken);
            if (existing != null)
            {
                await _context.DeleteAsync<HealthProblem>(existing.Id, cancellationToken);
            }
        }
    }
}
