using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public class AppointmentService 
    : BaseService<AppointmentDto, AppointmentCreateDto, AppointmentUpdateDto, Appointment>,
        IAppointmentService
{
    private readonly IAppointmentRepository _repository;
    
    public AppointmentService(IAppointmentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public override async Task<AppointmentDto> UpdateAsync(int id, AppointmentUpdateDto updateDto,
        CancellationToken cancellation = default)
    {
        var entity = updateDto.Adapt<Appointment>();
        entity.Id = id;
        
        await _repository.UpdateAsync(entity, cancellation);
        
        return entity.Adapt<AppointmentDto>();
    }

    public async Task<ICollection<AppointmentDto>> GetManyAsync(int doctorId, int patientId, 
        DateOnly date, int skip, int take, CancellationToken cancellation = default)
    {
        var entities = await _repository
            .GetManyAsync(doctorId, patientId, date, skip, take, cancellation);
        
        return entities.Adapt<ICollection<AppointmentDto>>();
    }

    public async Task ChangeApprovalStatusAsync(int id, bool isApproved, CancellationToken cancellation = default)
    {
        await _repository.ChangeStatusAsync(id, isApproved, cancellation);
    }
}
