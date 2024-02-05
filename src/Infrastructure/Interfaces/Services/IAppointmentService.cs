using Domain.Dtos;

namespace Infrastructure.Interfaces.Services;

public interface IAppointmentService : IBaseService<AppointmentDto, AppointmentCreateDto, AppointmentUpdateDto>
{
    Task<ICollection<AppointmentDto>> GetManyAsync(int doctorId, int patientId, DateOnly date, int skip, int take, 
        CancellationToken cancellation = default);
    
    Task ChangeApprovalStatusAsync(int id, bool isApproved, CancellationToken cancellation = default);
}
