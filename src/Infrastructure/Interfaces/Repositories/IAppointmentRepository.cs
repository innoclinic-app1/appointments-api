using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task ChangeStatusAsync(int id, bool isApproved, CancellationToken cancellation = default);
    
    Task<ICollection<Appointment>> GetManyAsync(int doctorId, int patientId, 
        DateOnly date, int skip, int take, CancellationToken cancellation = default);
}
