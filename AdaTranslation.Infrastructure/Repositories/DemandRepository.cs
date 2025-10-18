using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Enums;
using AdaTranslation.Infrastructure.Data;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class DemandRepository : IDemandRepository
    {
        private readonly ApplicationDbContext _context;
        public DemandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(DemandCreateDto demand, CancellationToken cancellationToken = default)
        {
            var newDemand = new Demand() 
            { 
                Description = demand.Description,
                StartDate = demand.StartDate,
                FinishDate = demand.FinishDate,
                Priority = demand.Priority,
                DemandType = demand.DemandType,
                Status = demand.Status,
                CenterId = 1, //Get from claim
                CreatedById = 1, //Get from claim
                CreatedDate = DateTime.UtcNow
            };
            await _context.Demands.AddAsync(newDemand, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
