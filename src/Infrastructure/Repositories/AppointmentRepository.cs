using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppointmentRepository(DataContext context) 
    : BaseRepository<Appointment>(context), IAppointmentRepository
{
    public override async Task RemoveAsync(int id, CancellationToken cancellation = default)
    {
        var countRows = await Context.Appointments
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync(cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(Appointment), id);
    }

    public override async Task UpdateAsync(Appointment entity, CancellationToken cancellation = default)
    {
        var countRows = await Context.Appointments
            .Where(a => a.Id == entity.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(a => a.PatientId, entity.PatientId)
                .SetProperty(a => a.DoctorId, entity.DoctorId)
                .SetProperty(a => a.ServiceId, entity.ServiceId)
                .SetProperty(a => a.DateTime, entity.DateTime)
                .SetProperty(a => a.IsApproved, entity.IsApproved), cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(entity), entity.Id);
    }
}
