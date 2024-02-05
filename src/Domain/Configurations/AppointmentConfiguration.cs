using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.PatientId)
            .IsRequired();
        
        builder.Property(a => a.DoctorId)
            .IsRequired();
        
        builder.Property(a => a.ServiceId)
            .IsRequired();
        
        builder.Property(a => a.Date)
            .IsRequired();
        
        builder.Property(a => a.Time)
            .IsRequired();
        
        builder.Property(a => a.IsApproved)
            .IsRequired();
        
        builder.HasOne(a => a.Result)
            .WithOne(r => r.Appointment)
            .HasForeignKey<Result>(r => r.AppointmentId);
    }
}
