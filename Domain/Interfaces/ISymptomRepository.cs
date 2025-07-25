using Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Domain.Interfaces
{
    public interface ISymptomRepository : IRepository<Symptom>
    {
        Task<IEnumerable<Symptom>> GetByIdsAsync(List<string> symptomIds);
    }
}
