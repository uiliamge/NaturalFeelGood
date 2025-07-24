using Amazon.DynamoDBv2.DataModel;
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

        public async Task<List<Organ>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Organ>(conditions).GetRemainingAsync();
        }

        public async Task<Organ?> GetByValueAsync(string value)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, value)
            };
            var result = await _context.ScanAsync<Organ>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(Organ entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, Organ updated)
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
                await _context.DeleteAsync<Organ>(existing.Id);
            }
        }
    }
}
