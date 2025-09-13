using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    public class DemandConfiguration : IEntityTypeConfiguration<Demand>
    {
        public void Configure(EntityTypeBuilder<Demand> builder)
        { 
            builder.ToTable(nameof(Demand));
 
            builder.HasKey(d => d.Id);
             
            builder.Property(d => d.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(d => d.StartDate)
                   .IsRequired();

            builder.Property(d => d.FinishDate)
                   .IsRequired();

            builder.Property(d => d.Priority)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(d => d.Status)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(d => d.DemandType)
                   .HasConversion<string>() 
                   .HasMaxLength(20);

            builder.Property(d => d.CreatedDate)
                   .HasDefaultValueSql("GETUTCDATE()"); 

            
            builder.HasOne(d => d.Center)
                   .WithMany(c => c.Demands)
                   .HasForeignKey(d => d.CenterId)
                   .OnDelete(DeleteBehavior.Cascade);
              
            builder.HasMany(d => d.DemandDetails)
                   .WithOne(dd => dd.Demand)
                   .HasForeignKey(dd => dd.DemandId)
                   .OnDelete(DeleteBehavior.Cascade);
 
            builder.HasIndex(d => new { d.CenterId, d.Status });
        }
    }
}

