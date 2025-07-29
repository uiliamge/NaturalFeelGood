using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Infrastructure.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly IDynamoDBContext _context;

        public MedicationRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Medication?> GetByBrandOrGenericNameAsync(string name)
        {
            var scanConditions = new List<ScanCondition>
            {
                new ScanCondition("BrandName.en", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name),
                new ScanCondition("BrandName.pt", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name),
                new ScanCondition("BrandName.es", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name),
                new ScanCondition("GenericName.en", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name),
                new ScanCondition("GenericName.pt", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name),
                new ScanCondition("GenericName.es", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name)
            };

            var search = _context.ScanAsync<Medication>(scanConditions);
            var results = await search.GetRemainingAsync();
            return results.FirstOrDefault();
        }

        public async Task<List<Medication>> GetAllAsync(CancellationToken cancellationToken)
        {
            var search = _context.ScanAsync<Medication>(new List<ScanCondition>());
            return await search.GetRemainingAsync(cancellationToken);
        }

        public async Task<Medication?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.LoadAsync<Medication>(id, cancellationToken);
        }

        public async Task InsertAsync(Medication entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, Medication updated, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(updated, cancellationToken);
        }

        public async Task DeleteAsync(string value, CancellationToken cancellationToken)
        {
            await _context.DeleteAsync<Medication>(value);
        }
    }
}
