using Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Domain.Interfaces
{
    public interface INaturalElementRepository : IRepository<NaturalElement>
    {
        Task<int> CountByElementTypeAsync(string value);
        Task<IEnumerable<NaturalElement>> GetByContraindicationTypeIdAsync(string contraindicationTypeId);
        Task<IEnumerable<NaturalElement>> GetByMedicationIdAsync(string id);
        Task<IEnumerable<NaturalElement>> GetByProblemIdAsync(string problemId);
        Task<IEnumerable<NaturalElement>> GetBySymptomIdAsync(string symptomId);
    }
}
