using AdaTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTranslation.Infrastructure.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable(nameof(Language));

            builder.HasKey(l => l.Id);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.HasMany(l => l.UserLanguages)
           .WithOne(ul => ul.Language)
           .HasForeignKey(ul => ul.LanguageId);

        }
    }
}
