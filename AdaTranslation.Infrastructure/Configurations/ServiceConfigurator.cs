using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(nameof(Service));

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Description)
               .IsRequired()
               .HasMaxLength(100);


        builder.HasMany(s => s.DemandDetails)
               .WithOne(dd => dd.Service)
               .HasForeignKey(dd => dd.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
}
