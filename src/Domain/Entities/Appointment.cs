namespace Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int ServiceId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public bool IsApproved { get; set; }
    
    public Result? Result { get; set; }
}
