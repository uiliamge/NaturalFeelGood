using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class SymptomRepository : ISymptomRepository
    {
        private readonly IDynamoDBContext _context;

        public SymptomRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Symptom>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Symptom>(conditions).GetRemainingAsync(cancellationToken);
        }

        public async Task<Symptom?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Id", ScanOperator.Equal, id)
                };
            var result = await _context.ScanAsync<Symptom>(conditions).GetRemainingAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Symptom entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, Symptom updated, CancellationToken cancellationToken)
        {
            var existing = await GetByIdAsync(value, cancellationToken);
            if (existing != null)
            {
                updated.Id = existing.Id;
                await _context.SaveAsync(updated, cancellationToken);
            }
        }

        public async Task DeleteAsync(string value, CancellationToken cancellationToken)
        {
            var existing = await GetByIdAsync(value, cancellationToken);
            if (existing != null)
            {
                await _context.DeleteAsync<Symptom>(existing.Id, cancellationToken);
            }
        }

        public async Task<IEnumerable<Symptom>> GetByIdsAsync(List<string> symptomIds)
        {
            var batch = _context.CreateBatchGet<Symptom>();
            foreach (var id in symptomIds)
            {
                batch.AddKey(id);
            }

            await batch.ExecuteAsync();
            return batch.Results;
        }
    }
}
