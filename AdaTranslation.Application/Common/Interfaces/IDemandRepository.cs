using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Manipulate Demand model
    /// </summary>
    public interface IDemandRepository
    {
        Task<DemandSummaryDto?> GetByIdAsync(
            long Id,
            UserRole role,
            long? userId,
            long? centerId,
            bool fetchAllData,
            CancellationToken cancellationToken = default);
        Task<Demand?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<PagedResult<DemandSummaryDto>> GetAsync(
            Page page,
            UserRole role,
            long? userId,
            long? centerId,
            bool fetchAllData,
            CancellationToken cancellationToken = default);
        Task<int> CreateAsync(Demand demand, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(Demand demand, CancellationToken cancellationToken = default);
    }
}
