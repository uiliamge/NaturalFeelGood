using Amazon.DynamoDBv2.DataModel;
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

        public async Task<List<Symptom>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Symptom>(conditions).GetRemainingAsync();
        }

        public async Task<Symptom?> GetByIdAsync(string id)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, id)
            };
            var result = await _context.ScanAsync<Symptom>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Symptom entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, Symptom updated)
        {
            var existing = await GetByIdAsync(value);
            if (existing != null)
            {
                updated.Id = existing.Id;
                await _context.SaveAsync(updated);
            }
        }

        public async Task DeleteAsync(string value)
        {
            var existing = await GetByIdAsync(value);
            if (existing != null)
            {
                await _context.DeleteAsync<Symptom>(existing.Id);
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
