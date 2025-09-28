using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class ServiceRepository(ApplicationDbContext context) : IServiceRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Service>> GetAsync(CancellationToken cancellationToken = default)
        {
            var services = await _context.Services.ToListAsync(cancellationToken);

            if (services.Count != 0)
                return services;  
            return [];
        }
        public async Task<Service> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            Service? service = await _context.Services.FindAsync(id, cancellationToken);
            if (service != null)
                return service;

            throw new KeyNotFoundException($"Service with ID {id} was not found.");
        }
        public async Task CreateAsync(Service service, CancellationToken cancellationToken = default)
        {
            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(Service service, CancellationToken cancellationToken = default)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            Service? service = await _context.Services.FindAsync(id, cancellationToken);

            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync(cancellationToken);
            } 

        }
    }
}
