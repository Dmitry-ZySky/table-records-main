namespace Core.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T?> GetByIdAsync<Tid>(Tid id) where Tid : notnull;

    Task<IEnumerable<T>> GetAllAsync();
}
