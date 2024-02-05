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
                .SetProperty(a => a.Date, entity.Date)
                .SetProperty(a => a.Time, entity.Time)
                .SetProperty(a => a.IsApproved, entity.IsApproved), cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(entity), entity.Id);
    }

    public async Task ChangeStatusAsync(int id, bool isApproved, CancellationToken cancellation = default)
    {
        var countRows = await Context.Appointments
            .Where(a => a.Id == id)
            .ExecuteUpdateAsync(s => 
                s.SetProperty(a => a.IsApproved, isApproved), cancellation);

        if (countRows == 0)
            throw new NotFoundException(nameof(Appointment), id);
    }

    public async Task<ICollection<Appointment>> GetManyAsync(int doctorId, int patientId, DateOnly date, int skip, int take,
        CancellationToken cancellation = default)
    {
        var query = Context.Appointments.AsQueryable();

        if (doctorId != 0)
        {
            query = query.Where(a => a.DoctorId == doctorId);
        }
        
        if (patientId != 0)
        {
            query = query.Where(a => a.PatientId == patientId);
        }

        if (date != default)
        {
            query = query.Where(a => a.Date == date);
        }
        
        return await query
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellation);
    }
}
