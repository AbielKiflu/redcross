using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    internal class DemandDetailConfiguration : IEntityTypeConfiguration<DemandDetail>
    {
        public void Configure(EntityTypeBuilder<DemandDetail> builder)
        {
            builder.ToTable(nameof(DemandDetail));

            builder.HasKey(dd => dd.Id);

            builder.Property(dd => dd.ResponsiblePersonEmail)
                   .IsRequired()
                   .HasMaxLength(50); 

            builder.Property(dd => dd.Message)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(dd => dd.Duration);

            builder.Property(dd => dd.CreatedDate)
                   .IsRequired();

            // Foreign key relationships
            builder.HasOne(dd => dd.Demand)
                   .WithMany(d => d.DemandDetails)
                   .HasForeignKey(dd => dd.DemandId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dd => dd.Service)
                   .WithMany(s => s.DemandDetails)
                   .HasForeignKey(dd => dd.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
