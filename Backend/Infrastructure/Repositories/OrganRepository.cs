using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class OrganRepository : IOrganRepository
    {
        private readonly IDynamoDBContext _context;

        public OrganRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Organ>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Organ>(conditions).GetRemainingAsync(cancellationToken);
        }

        public async Task<Organ?> GetByIdAsync(string value, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Id", ScanOperator.Equal, value)
                };
            var result = await _context.ScanAsync<Organ>(conditions).GetRemainingAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Organ entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, Organ updated, CancellationToken cancellationToken)
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
                await _context.DeleteAsync<Organ>(existing.Id, cancellationToken);
            }
        }
    }
}
