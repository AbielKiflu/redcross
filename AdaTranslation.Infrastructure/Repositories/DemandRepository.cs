using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Domain;
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

        public async Task<PagedResult<DemandSummaryDto>> Get(Page page, CancellationToken cancellationToken = default)
        {
            if (page.PageNumber < 1 || page.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters.");

            var query = _context.Demands
                .AsNoTracking()
                .Include(d => d.CreatedBy)
                .Include(d => d.Center);

            // Count before paging (still runs in SQL)
            var totalCount = await query.CountAsync(cancellationToken);

            // Apply paging and projection in the same query
            var items = await query
                .OrderBy(d => d.Id)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .Select(d => new DemandSummaryDto
                {
                    Id = d.Id,
                    Subject = d.Subject,
                    Status = d.Status,
                    Priority = d.Priority,
                    DemandType = d.DemandType,
                    CenterName = d.Center.Description,
                    CreatedByUserName = d.CreatedBy.FirstName,
                    CreatedDate = d.CreatedDate,
                    Description = d.Description
                })
                .ToListAsync(cancellationToken);

            return new PagedResult<DemandSummaryDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = page.PageNumber,
                PageSize = page.PageSize
            };

        }

        public async Task<DemandSummaryDto> GetById(long id, CancellationToken cancellationToken = default)
        {
            var result = await _context.Demands
                   .AsNoTracking()
                   .Include(d => d.Center)
                   .Include(d=> d.CreatedBy)
                   .FirstAsync(d => d.Id == id, cancellationToken);

            var demandSummary = new DemandSummaryDto()
            {
                Id = id,
                CenterName = result.Center.Description,
                Subject = result.Subject,
                Description = result.Description,
                CreatedByUserName = result.CreatedBy.FirstName,
                CreatedDate = result.CreatedDate,
                DemandType = result.DemandType,
                Priority = result.Priority,
                Status = result.Status
            };
            return demandSummary;
        }

        public async Task<int> CreateAsync(DemandCreateDto demand, CancellationToken cancellationToken = default)
        {
            var newDemand = new Demand() 
            { 
                Subject = demand.Subject,
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
                Subject = result.Subject,
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
                Subject = result.Subject,
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
