using AdaTranslation.Application.Demands.Dtos;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Manipulate Demand model
    /// </summary>
    public interface IDemandRepository
    {
        Task<int> CreateAsync(DemandCreateDto demand, CancellationToken cancellationToken = default);
        Task<int> UpdateAdminAsync(DemandUpdateAdmin demand, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(DemandUpdate demand, CancellationToken cancellationToken = default);
    }
}
