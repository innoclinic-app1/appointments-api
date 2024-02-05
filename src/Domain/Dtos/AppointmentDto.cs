namespace Domain.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int ServiceId { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsApproved { get; set; }
}
