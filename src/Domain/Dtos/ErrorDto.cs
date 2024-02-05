namespace Domain.Dtos;

public class ErrorDto
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}
