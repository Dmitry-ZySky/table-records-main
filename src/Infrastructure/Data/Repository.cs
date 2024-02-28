using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class Repository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly TableImportRecordsContext _context;

    public Repository(TableImportRecordsContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task<T?> GetByIdAsync<Tid>(Tid id) where Tid : notnull
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}
