using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
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

        public async Task<List<NaturalElement>> GetAllAsync(CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<NaturalElement>(conditions).GetRemainingAsync(cancellationToken);
        }

        public async Task<NaturalElement?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Id", ScanOperator.Equal, id)
                };
            var result = await _context.ScanAsync<NaturalElement>(conditions).GetRemainingAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        public async Task InsertAsync(NaturalElement entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string value, NaturalElement updated, CancellationToken cancellationToken)
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
                await _context.DeleteAsync<NaturalElement>(existing.Id, cancellationToken);
            }
        }

        public async Task<IEnumerable<NaturalElement>> GetByMedicationIdAsync(string medicationId)
        {
            var relationConditions = new List<ScanCondition>
                {
                    new ScanCondition("MedicationId", ScanOperator.Equal, medicationId)
                };
            var relationList = await _context.ScanAsync<NaturalElementXMedication>(relationConditions).GetRemainingAsync();

            if (relationList == null || relationList.Count == 0)
                return Enumerable.Empty<NaturalElement>();

            var naturalElementsIds = relationList.Select(x => x.NaturalElementId).Distinct().ToList();

            var naturalElements = new List<NaturalElement>();
            foreach (var naturalElementId in naturalElementsIds)
            {
                NaturalElement? naturalElement = await GetByIdAsync(naturalElementId, CancellationToken.None);
                if (naturalElement != null)
                    naturalElements.Add(naturalElement);
            }

            return naturalElements;
        }

        public async Task<IEnumerable<NaturalElement>> GetByProblemIdAsync(string problemId)
        {
            var relationConditions = new List<ScanCondition>
                {
                    new ScanCondition("ProblemId", ScanOperator.Equal, problemId)
                };
            var relationList = await _context.ScanAsync<NaturalElementXProblem>(relationConditions).GetRemainingAsync();

            if (relationList == null || relationList.Count == 0)
                return Enumerable.Empty<NaturalElement>();

            var naturalElementsIds = relationList.Select(x => x.NaturalElementId).Distinct().ToList();

            var naturalElements = new List<NaturalElement>();
            foreach (var naturalElementId in naturalElementsIds)
            {
                NaturalElement? naturalElement = await GetByIdAsync(naturalElementId, CancellationToken.None);
                if (naturalElement != null)
                    naturalElements.Add(naturalElement);
            }

            return naturalElements;
        }

        public async Task<IEnumerable<NaturalElement>> GetBySymptomIdAsync(string symptomId)
        {
            var relationConditions = new List<ScanCondition>
                {
                    new ScanCondition("SymptomId", ScanOperator.Equal, symptomId)
                };
            var relationList = await _context.ScanAsync<NaturalElementXSymptom>(relationConditions).GetRemainingAsync();

            if (relationList == null || relationList.Count == 0)
                return Enumerable.Empty<NaturalElement>();

            var naturalElementsIds = relationList.Select(x => x.NaturalElementId).Distinct().ToList();

            var naturalElements = new List<NaturalElement>();
            foreach (var naturalElementId in naturalElementsIds)
            {
                NaturalElement? naturalElement = await GetByIdAsync(naturalElementId, CancellationToken.None);
                if (naturalElement != null)
                    naturalElements.Add(naturalElement);
            }

            return naturalElements;
        }

        public async Task<IEnumerable<NaturalElement>> GetByContraindicationTypeIdAsync(string contraindicationTypeId)
        {
            var relationConditions = new List<ScanCondition>
                {
                    new ScanCondition("ContraindicationTypeId", ScanOperator.Equal, contraindicationTypeId)
                };
            var relationList = await _context.ScanAsync<NaturalElementXContraindicationType>(relationConditions).GetRemainingAsync();

            if (relationList == null || relationList.Count == 0)
                return Enumerable.Empty<NaturalElement>();

            var naturalElementsIds = relationList.Select(x => x.NaturalElementId).Distinct().ToList();

            var naturalElements = new List<NaturalElement>();
            foreach (var naturalElementId in naturalElementsIds)
            {
                NaturalElement? naturalElement = await GetByIdAsync(naturalElementId, CancellationToken.None);
                if (naturalElement != null)
                    naturalElements.Add(naturalElement);
            }

            return naturalElements;
        }

        public async Task<int> CountByElementTypeAsync(string elementType)
        {
            var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Type", ScanOperator.Equal, elementType)
                };

            var search = _context.ScanAsync<NaturalElement>(conditions);
            var results = await search.GetRemainingAsync();
            return results.Count;
        }
    }
}
