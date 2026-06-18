using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Enums;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;


namespace AdaTranslation.Infrastructure.Repositories
{
    public class DemandRepository : IDemandRepository
    {
        private readonly ApplicationDbContext _context;
        public DemandRepository(ApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
        }

        public async Task<PagedResult<DemandSummaryDto>> GetAsync(
            Page page,
            UserRole role,
            long? userId,
            long? centerId,
            bool fetchAllData,
            CancellationToken cancellationToken = default)
        {
            if (page.PageNumber < 1 || page.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters.");

            var query = _context.Demands.AsNoTracking();

            if (!fetchAllData)
            {
                if (role == UserRole.Client)
                {
                    query = query.Where(d => d.CreatedById == userId || d.CenterId == centerId);
                }
                else if (role == UserRole.Mediator)
                {
                    query = query.Where(d => d.DemandedUserId == userId);
                }
            }

            var totalCount = await query.CountAsync(cancellationToken);

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
                    CenterName = d.Center != null ? d.Center.Description : "No Center",
                    CreatedByUserName = d.CreatedBy != null ? d.CreatedBy.FirstName : "System",
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

        public async Task<DemandSummaryDto?> GetByIdAsync(
            long id,
            UserRole role,
            long? userId,
            long? centerId,
            bool fetchAllData,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Demands.AsNoTracking().Where(d => d.Id == id);

            if (!fetchAllData)
            {
                if (role == UserRole.Client)
                {
                    query = query.Where(d => d.CreatedById == userId || d.CenterId == centerId);
                }
                else if (role == UserRole.Mediator)
                {
                    query = query.Where(d => d.DemandedUserId == userId);
                }
            }

            return await query
                .Select(d => new DemandSummaryDto
                {
                    Id = d.Id,
                    Subject = d.Subject,
                    Description = d.Description,
                    Status = d.Status,
                    Priority = d.Priority,
                    DemandType = d.DemandType,
                    CreatedDate = d.CreatedDate,
                    CenterName = d.Center != null ? d.Center.Description : "No Center Assigned",
                    CreatedByUserName = d.CreatedBy != null ? d.CreatedBy.FirstName : "System"
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> CreateAsync(Demand demand, CancellationToken cancellationToken = default)
        {
            await _context.Demands.AddAsync(demand, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(Demand demand, CancellationToken cancellationToken = default)
        {
            var result = await _context.Demands
                 .AsNoTracking()
                 .FirstAsync(d => d.Id == demand.Id, cancellationToken);

            result.Update(demand.Subject, demand.Description, demand.DemandType);
            _context.Demands.Update(result);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Demand?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _context.Demands
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }
    }
}
