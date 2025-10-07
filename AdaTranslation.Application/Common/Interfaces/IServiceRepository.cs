using AdaTranslation.Application.Services.Dtos;
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// This interface is temp. for the moment services are going to be created by the database admin
    /// </summary>
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAsync(CancellationToken cancellationToken = default);
        Task<Service> GetByIdAsync(int id, CancellationToken cancellationToken = default); // To be considered
        Task CreateAsync(string description, CancellationToken cancellationToken = default);
        Task UpdateAsync(ServiceDto service, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
