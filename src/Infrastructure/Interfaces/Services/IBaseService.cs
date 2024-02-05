namespace Infrastructure.Interfaces.Services;

public interface IBaseService<T, in TCreate, in TUpdate>
{
    Task DeleteAsync(int id, CancellationToken cancellation = default);
    
    Task<T> GetOneAsync(int id, CancellationToken cancellation = default);
    
    Task<T> CreateAsync(TCreate create, CancellationToken cancellation = default);
    
    Task<T> UpdateAsync(int id, TUpdate update, CancellationToken cancellation = default);
    
    Task<ICollection<T>> GetManyAsync(int skip, int take, CancellationToken cancellation = default);
}
