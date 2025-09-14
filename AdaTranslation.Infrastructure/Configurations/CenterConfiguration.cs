using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.ToTable("Center");

            builder.HasKey(c => c.ID); //PK

            // Properties
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.Address)
                .HasMaxLength(250);

            builder.Property(c => c.Contact)
                .HasMaxLength(13);


            // Center has many Users
            builder.HasMany(c => c.Users)
                   .WithOne(u => u.Center)
                   .HasForeignKey(u => u.CenterID)
                   .OnDelete(DeleteBehavior.Restrict);

            // Center has many Demands
            builder.HasMany(c => c.Demands)
                   .WithOne(d => d.Center)
                   .HasForeignKey(d => d.CenterID)
                   .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
