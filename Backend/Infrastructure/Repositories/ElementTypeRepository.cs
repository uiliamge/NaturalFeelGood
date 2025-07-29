using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
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

        public async Task<List<ElementType>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            var result = await _context.ScanAsync<ElementType>(conditions).GetRemainingAsync(cancellationToken);
            return result;
        }

        public async Task<ElementType?> GetByIdAsync(string value, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Id", ScanOperator.Equal, value)
                };
            var result = await _context.ScanAsync<ElementType>(conditions).GetRemainingAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(ElementType element, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(element, cancellationToken);
        }

        public async Task UpdateAsync(string value, ElementType updated, CancellationToken cancellationToken)
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
                await _context.DeleteAsync<ElementType>(existing.Id, cancellationToken);
            }
        }
    }
}
