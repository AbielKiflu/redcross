using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Domain;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Manipulate Demand model
    /// </summary>
    public interface IDemandRepository
    {
        Task<DemandSummaryDto> GetById(long id, CancellationToken cancellationToken=default);
        Task<PagedResult<DemandSummaryDto>> Get(Page page,CancellationToken cancellationToken =default);
        Task<int> CreateAsync(DemandCreateDto demand, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(DemandUpdate demand, CancellationToken cancellationToken = default);
    }
}
