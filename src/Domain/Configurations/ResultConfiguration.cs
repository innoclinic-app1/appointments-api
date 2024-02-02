using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.AppointmentId)
            .IsRequired();
        
        builder.Property(r => r.Complaints)
            .HasMaxLength(1028)
            .IsRequired();
        
        builder.Property(r => r.Conclusion)
            .HasMaxLength(1028)
            .IsRequired();
        
        builder.Property(r => r.Recommendations)
            .HasMaxLength(1028)
            .IsRequired();

        builder.HasOne(r => r.Appointment)
            .WithOne(a => a.Result)
            .HasForeignKey<Result>(r => r.AppointmentId);
    }
}
