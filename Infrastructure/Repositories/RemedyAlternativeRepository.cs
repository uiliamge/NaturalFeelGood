using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class RemedyAlternativeRepository : IRemedyAlternativeRepository
    {
        private readonly IDynamoDBContext _context;

        public RemedyAlternativeRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<RemedyAlternative>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<RemedyAlternative>(conditions).GetRemainingAsync();
        }

        public async Task<RemedyAlternative?> GetByValueAsync(string value)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Type", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, value)
            };
            var result = await _context.ScanAsync<RemedyAlternative>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(RemedyAlternative entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, RemedyAlternative updated)
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
                await _context.DeleteAsync<RemedyAlternative>(existing.Id);
            }
        }
    }
}
