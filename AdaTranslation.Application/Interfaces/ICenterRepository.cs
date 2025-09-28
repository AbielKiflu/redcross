using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries.Center;

namespace AdaTranslation.Domain.Interfaces
{
    /// <summary>
    /// This interface is temp. for the moment centers are going to be created by the database admin
    /// </summary>
    public interface ICenterRepository
    {
        Task<PagedResult<CenterDto>> Get(GetCenterQuery request, CancellationToken cancellationToken);

        Task<CenterDto> GetById(GetCenterByIdQuery request, CancellationToken cancellationToken);

    }
}
