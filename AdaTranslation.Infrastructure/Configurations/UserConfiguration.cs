using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.ID);

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(u => u.Telephone)
               .HasMaxLength(13);

        builder.Property(u => u.Email)
               .HasMaxLength(30);

        builder.Property(u => u.GoogleId)
                .IsRequired(false)
               .HasMaxLength(50);

        builder.Property(u => u.PauseStartDate)
               .IsRequired(false);

        builder.Property(u => u.PauseEndDate)
               .IsRequired(false);

        builder.Property(u => u.UserRole)
               .HasConversion<int>()   // store enum as int check later
               .IsRequired();

        // Relationships
        builder.HasOne(u => u.Center)  
               .WithMany(c => c.Users)             
               .HasForeignKey(u => u.CenterID)     
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasMany(u => u.UserLanguages)     
               .WithOne(ul => ul.User)            
               .HasForeignKey(ul => ul.UserId);
    }
}
}
