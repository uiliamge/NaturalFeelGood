using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly IDynamoDBContext _context;

        public ProblemRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Problem>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Problem>(conditions).GetRemainingAsync();
        }

        public async Task<Problem?> GetByIdAsync(string value)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, value)
            };
            var result = await _context.ScanAsync<Problem>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Problem entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, Problem updated)
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
                await _context.DeleteAsync<Problem>(existing.Id);
            }
        }
    }
}
