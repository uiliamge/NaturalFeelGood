using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class ElementTypeRepository : IElementTypeRepository
    {
        private readonly IDynamoDBContext _context;

        public ElementTypeRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<ElementType>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            var result = await _context.ScanAsync<ElementType>(conditions).GetRemainingAsync();
            return result;
        }

        public async Task<ElementType?> GetByValueAsync(string value)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Value", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, value)
            };
            var result = await _context.ScanAsync<ElementType>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(ElementType element)
        {
            await _context.SaveAsync(element);
        }

        public async Task UpdateAsync(string value, ElementType updated)
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
                await _context.DeleteAsync<ElementType>(existing.Id);
            }
        }
    }
}
