namespace Domain.Dtos;

public class AppointmentCreate
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int ServiceId { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsApproved { get; set; }
}
