using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ResultRepository(DataContext context) : BaseRepository<Result>(context), IResultRepository
{
    public override async Task RemoveAsync(int id, CancellationToken cancellation = default)
    {
        var countRows = await Context.Results
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync(cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(Result), id);
    }

    public override async Task UpdateAsync(Result entity, CancellationToken cancellation = default)
    {
        var countRows = await Context.Results
            .Where(r => r.Id == entity.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(r => r.AppointmentId, entity.AppointmentId)
                .SetProperty(r => r.Complaints, entity.Complaints)
                .SetProperty(r => r.Conclusion, entity.Conclusion)
                .SetProperty(r => r.Recommendations, entity.Recommendations), cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(entity), entity.Id);
    }
}
