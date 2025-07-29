using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
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

        public async Task<List<Problem>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Problem>(conditions).GetRemainingAsync(cancellationToken);
        }

        public async Task<Problem?> GetByIdAsync(string value, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Id", ScanOperator.Equal, value)
                };
            var result = await _context.ScanAsync<Problem>(conditions).GetRemainingAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Problem entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, Problem updated, CancellationToken cancellationToken)
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
                await _context.DeleteAsync<Problem>(existing.Id, cancellationToken);
            }
        }
    }
}
