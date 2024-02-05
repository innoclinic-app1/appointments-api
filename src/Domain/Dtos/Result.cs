namespace Domain.Dtos;

public class Result
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string Complaints { get; set; } = null!;
    public string Conclusion { get; set; } = null!;
    public string Recommendations { get; set; } = null!;
}
