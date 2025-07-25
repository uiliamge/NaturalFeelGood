﻿namespace Domain.Interfaces
{
    // Base repository interface for entities with string key
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task InsertAsync(T entity);
        Task UpdateAsync(string value, T updated);
        Task DeleteAsync(string value);
    }
}
