using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly LeaveManagementDbContext _dbContext;
    public GenericRepository(LeaveManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<T> Table
    {
        get
        {
            return _dbContext.Set<T>();
        }
    }
    public async Task<T> Add(T entity)
    {
       await Table.AddAsync(entity);
       await _dbContext.SaveChangesAsync();
       return entity;
    }
    
    public async Task Delete(T entity)
    {
        Table.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }

    public async Task<T> Get(int id)
    {
        var entity = await Table.FindAsync(id);
        if (entity!=null)
        {
            return entity;
        }
        throw new NotFoundException(nameof(T), id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await Table.ToListAsync();
    }

    public async Task Update(T entity)
    {
       _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
