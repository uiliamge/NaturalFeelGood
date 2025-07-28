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

        public async Task<List<BodySystem>> GetAllAsync()
        {
            var search = _context.ScanAsync<BodySystem>(new List<ScanCondition>());
            return await search.GetRemainingAsync();
        }

        public async Task<BodySystem?> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<BodySystem>(id);
        }

        public async Task InsertAsync(BodySystem entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, BodySystem updated)
        {
            await _context.SaveAsync(updated);
        }

        public async Task DeleteAsync(string value)
        {
            await _context.DeleteAsync<BodySystem>(value);
        }
    }
}
