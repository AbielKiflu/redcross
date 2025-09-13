using AdaTranslation.Domain.Entities;
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
        public DbSet<Resident> Resident => Set<Resident>();
        public DbSet<Demand> Demand => Set<Demand>();
        public DbSet<DemandDetail> DemandDetail => Set<DemandDetail>();
        public DbSet<UserLanguage> UserLanguage => Set<UserLanguage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

}

