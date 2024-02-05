using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
{
    protected readonly DataContext Context;
    
    protected BaseRepository(DataContext context)
    {
        Context = context;
    }
    
    public async Task InsertAsync(T entity, CancellationToken cancellation = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellation);
        
        await Context.SaveChangesAsync(cancellation);
    }
    
    public async Task<T> GetOneAsync(int id, CancellationToken cancellation = default)
    {
        var entity = await Context.Set<T>().FindAsync(id, cancellation)
            ?? throw new NotFoundException(nameof(T), id);

        return entity;
    }

    public async Task<IEnumerable<T>> GetManyAsync(int skip, int take, CancellationToken cancellation = default)
    {
        return await Context.Set<T>().Skip(skip).Take(take).ToListAsync(cancellation);
    }
    
    public abstract Task RemoveAsync(int id, CancellationToken cancellation = default);
    
    public abstract Task UpdateAsync(T entity, CancellationToken cancellation = default);
}
