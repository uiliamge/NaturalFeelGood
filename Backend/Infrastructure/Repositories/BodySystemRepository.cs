using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class BodySystemRepository : IBodySystemRepository
    {
        private readonly IDynamoDBContext _context;

        public BodySystemRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<BodySystem>> GetAllAsync(CancellationToken cancellationToken)
        {
            var search = _context.ScanAsync<BodySystem>(new List<ScanCondition>());
            return await search.GetRemainingAsync(cancellationToken);
        }

        public async Task<BodySystem?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.LoadAsync<BodySystem>(id, cancellationToken);
        }

        public async Task InsertAsync(BodySystem entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, BodySystem updated, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(updated, cancellationToken);
        }

        public async Task DeleteAsync(string value, CancellationToken cancellationToken)
        {
            await _context.DeleteAsync<BodySystem>(value, cancellationToken);
        }
    }
}
