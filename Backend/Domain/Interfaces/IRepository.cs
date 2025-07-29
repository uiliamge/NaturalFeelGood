namespace Domain.Interfaces
{
    // Base repository interface for entities with string key
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task InsertAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(string value, T updated, CancellationToken cancellationToken);
        Task DeleteAsync(string value, CancellationToken cancellationToken);
    }
}
