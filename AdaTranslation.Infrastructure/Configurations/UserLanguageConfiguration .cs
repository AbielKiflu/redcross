using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        { 
            builder.ToTable(nameof(UserLanguage));
             
            builder.HasKey(ul => ul.Id);
             
            builder.HasOne(ul => ul.User)
                   .WithMany(u => u.UserLanguages)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ul => ul.Language)
                   .WithMany(l => l.UserLanguages)
                   .HasForeignKey(ul => ul.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);
           
            builder.HasIndex(ul => new { ul.UserId, ul.LanguageId })
                   .IsUnique();  
        }
    }
}
