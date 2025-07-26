using Domain.Interfaces;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Domain.Interfaces
{
    public interface INaturalElementRepository : IRepository<NaturalElement>
    {
        Task<IEnumerable<NaturalElement>> GetByMedicationIdAsync(string id);
    }
}
