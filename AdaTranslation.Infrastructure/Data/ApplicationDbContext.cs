using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdaTranslation.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User => Set<User>();
        public DbSet<Center> Center => Set<Center>();
        public DbSet<Service> Service => Set<Service>();
        public DbSet<Language> Language => Set<Language>();
        public DbSet<Demand> Demand => Set<Demand>();
        public DbSet<DemandDetail> DemandDetail => Set<DemandDetail>();
        public DbSet<UserLanguage> UserLanguage => Set<UserLanguage>();
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CenterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new DemandConfiguration());
            modelBuilder.ApplyConfiguration(new DemandDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
        }
    }

}

