using Domain.Dtos;

namespace Infrastructure.Interfaces.Services;

public interface IAppointmentService : IBaseService<Appointment, AppointmentCreate, AppointmentUpdate>
{
    Task<ICollection<Appointment>> GetManyAsync(int doctorId, int patientId, DateOnly date, int skip, int take, 
        CancellationToken cancellation = default);
    
    Task ChangeApprovalStatusAsync(int id, bool isApproved, CancellationToken cancellation = default);
}
