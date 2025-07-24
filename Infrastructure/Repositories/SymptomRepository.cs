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

        public async Task<Symptom?> GetByValueAsync(string value)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, value)
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
            var existing = await GetByValueAsync(value);
            if (existing != null)
            {
                updated.Id = existing.Id;
                await _context.SaveAsync(updated);
            }
        }

        public async Task DeleteAsync(string value)
        {
            var existing = await GetByValueAsync(value);
            if (existing != null)
            {
                await _context.DeleteAsync<Symptom>(existing.Id);
            }
        }
    }
}
