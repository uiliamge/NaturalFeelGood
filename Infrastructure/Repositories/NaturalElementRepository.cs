using Amazon.DynamoDBv2.DataModel;
using Domain.Entities;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class NaturalElementRepository : INaturalElementRepository
    {
        private readonly IDynamoDBContext _context;

        public NaturalElementRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<NaturalElement>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<NaturalElement>(conditions).GetRemainingAsync();
        }

        public async Task<NaturalElement?> GetByIdAsync(string id)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, id)
            };
            var result = await _context.ScanAsync<NaturalElement>(conditions).GetRemainingAsync();
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(NaturalElement entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task UpdateAsync(string value, NaturalElement updated)
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
                await _context.DeleteAsync<NaturalElement>(existing.Id);
            }
        }

        public async Task<IEnumerable<NaturalElement>> GetByMedicationIdAsync(string medicationId)
        {
            var relationConditions = new List<ScanCondition>
            {
                new ScanCondition("MedicationId", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, medicationId)
            };
            var relationList = await _context.ScanAsync<MedicationXRemedyAlternative>(relationConditions).GetRemainingAsync();

            if (relationList == null || relationList.Count == 0)
                return Enumerable.Empty<NaturalElement>();

            var naturalElementsIds = relationList.Select(x => x.NaturalElementId).Distinct().ToList();

            var naturalElements = new List<NaturalElement>();
            foreach (var naturalElementId in naturalElementsIds)
            {
                NaturalElement? naturalElement = await GetByIdAsync(naturalElementId);
                if (naturalElement != null)
                    naturalElements.Add(naturalElement);
            }

            return naturalElements;
        }
    }
}
