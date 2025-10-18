using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

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

        public async Task<int> UpdateAdminAsync(DemandUpdateAdmin demand, CancellationToken cancellationToken = default)
        {
            var result = await _context.Demands
                   .AsNoTracking()
                   .FirstAsync(d => d.Id == demand.Id, cancellationToken);

            var updateDemand = new Demand()
            {
                Id = result.Id,
                Description = result.Description,
                StartDate = demand.StartDate,
                FinishDate = demand.FinishDate,
                Priority = result.Priority,
                DemandType = demand.DemandType,
                Status = demand.Status,
                CenterId = result.CenterId,
                CreatedById = result.CreatedById,
                CreatedDate = result.CreatedDate,
            };
            _context.Demands.Update(updateDemand);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(DemandUpdate demand, CancellationToken cancellationToken = default)
        {
            var result = await _context.Demands
                 .AsNoTracking()
                 .FirstAsync(d => d.Id == demand.Id, cancellationToken);

            var updateDemand = new Demand()
            {
                Id = result.Id,
                Description = result.Description,
                StartDate = result.StartDate,// Maybe allow change the dates and some other datas
                FinishDate = result.FinishDate,
                Priority = result.Priority,
                DemandType = result.DemandType,
                Status = demand.Status,
                CenterId = result.CenterId,
                CreatedById = result.CreatedById,
                CreatedDate = result.CreatedDate,
            };
            _context.Demands.Update(updateDemand);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
