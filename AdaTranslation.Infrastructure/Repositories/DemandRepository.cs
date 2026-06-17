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
        private readonly ICurrentUserService _currentUser;
        public DemandRepository(ApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<PagedResult<DemandSummaryDto>> Get(Page page, CancellationToken cancellationToken = default)
        {
            if (page.PageNumber < 1 || page.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters.");

            var query = _context.Demands.AsNoTracking();

            query = _currentUser.Role switch
            {
                UserRole.Admin => query,
                UserRole.Coordinator => query,
                UserRole.Client => query.Where(d => d.CreatedById == _currentUser.UserId || d.CenterId == _currentUser.CenterId),
                UserRole.Mediator => query.Where(d => d.DemandedUserId == _currentUser.UserId),
                _ => query.Where(d => false) // Deny access by default if role is unhandled
            };

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
        .OrderBy(d => d.Id) // Sorting is mandatory for predictable Skip/Take behavior
        .Skip((page.PageNumber - 1) * page.PageSize)
        .Take(page.PageSize)
        .Select(d => new DemandSummaryDto
        {
            Id = d.Id,
            Subject = d.Subject,
            Status = d.Status,
            Priority = d.Priority,
            DemandType = d.DemandType,
            CenterName = d.Center.Description,     // EF handles the JOIN automatically
            CreatedByUserName = d.CreatedBy.FirstName, // EF handles the JOIN automatically
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
            var query = _context.Demands.AsNoTracking(); 
           
            query = _currentUser.Role switch
            {
                UserRole.Admin => query,
                UserRole.Coordinator => query,
                UserRole.Client => query.Where(d => d.CreatedById == _currentUser.UserId || d.CenterId == _currentUser.CenterId),
                UserRole.Mediator => query.Where(d => d.DemandedUserId == _currentUser.UserId),
                _ => query.Where(d => false)
            };
             
            var demandSummary = await query
                .Where(d => d.Id == id)
                .Select(d => new DemandSummaryDto
                {
                    Id = d.Id,
                    Subject = d.Subject,
                    Description = d.Description,
                    Status = d.Status,
                    Priority = d.Priority,
                    DemandType = d.DemandType,
                    CreatedDate = d.CreatedDate,
                    CenterName = d.Center.Description,     // EF automatically JOINs 'Center'
                    CreatedByUserName = d.CreatedBy.FirstName // EF automatically JOINs 'CreatedBy'
                })
                .FirstOrDefaultAsync(cancellationToken); 
            
            if (demandSummary == null)
                throw new KeyNotFoundException($"Demand with ID {id} was not found or you do not have permission to view it.");

            return demandSummary;
        }

        public async Task<int> CreateAsync(DemandCreateDto demand, CancellationToken cancellationToken = default)
        {
            var newDemand = new Demand(

                demand.Subject,
                demand.Description,
                1,
                1,
                DemandType.Site
            );
            await _context.Demands.AddAsync(newDemand, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(DemandUpdate demand, CancellationToken cancellationToken = default)
        {
            var result = await _context.Demands
                 .AsNoTracking()
                 .FirstAsync(d => d.Id == demand.Id, cancellationToken);

            result.Update(demand.Subject, demand.Description, demand.DemandType);
            _context.Demands.Update(result);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
