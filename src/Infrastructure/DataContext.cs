using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Result> Results { get; set; } = null!;
    
    public DbSet<Appointment> Appointments { get; set; } = null!;
}
