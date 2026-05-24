using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Services.Dtos;
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
        public async Task CreateAsync(string description, CancellationToken cancellationToken = default)
        {
            var newService = new Service(description);
            await _context.Services.AddAsync(newService, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(ServiceDto service, CancellationToken cancellationToken = default)
        {
            var updateService = new Service(service.Id,service.Description);
            _context.Services.Update(updateService);
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
