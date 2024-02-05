using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public abstract class BaseService<TDto, TCreateDto, TUpdateDto, TEntity> 
    : IBaseService<TDto, TCreateDto, TUpdateDto> where TEntity : class
{
    private readonly IBaseRepository<TEntity> _repository;

    protected BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task DeleteAsync(int id, CancellationToken cancellation = default)
    {
        await _repository.RemoveAsync(id, cancellation);
    }

    public async Task<TDto> GetOneAsync(int id, CancellationToken cancellation = default)
    {
        var entity = await _repository.GetOneAsync(id, cancellation);
        
        return entity.Adapt<TDto>();
    }

    public async Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellation = default)
    {
        var entity = createDto.Adapt<TEntity>();
        
        await _repository.InsertAsync(entity, cancellation);
        
        return entity.Adapt<TDto>();
    }
    
    public async Task<ICollection<TDto>> GetManyAsync(int skip, int take, CancellationToken cancellation = default)
    {
        var entities = await _repository.GetManyAsync(skip, take, cancellation);
        
        return entities.Adapt<ICollection<TDto>>();
    }
    
    public abstract Task<TDto> UpdateAsync(int id, TUpdateDto updateDto, CancellationToken cancellation = default);
}
