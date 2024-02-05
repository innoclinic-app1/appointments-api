using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public class ResultService : BaseService<ResultDto, ResultCreateDto, ResultUpdateDto, Result>, IResultService
{
    private readonly IResultRepository _repository;
    
    public ResultService(IResultRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public override async Task<ResultDto> UpdateAsync(int id, ResultUpdateDto updateDto, CancellationToken cancellation = default)
    {
        var entity = updateDto.Adapt<Result>();
        entity.Id = id;

        await _repository.UpdateAsync(entity, cancellation);

        return entity.Adapt<ResultDto>();
    }
}
