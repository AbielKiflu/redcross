using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries;

namespace AdaTranslation.Domain.Interfaces
{
    /// <summary>
    ///  A repo to make a crud on the table center
    /// </summary>
    public interface ICenterRepository
    {
        Task<PagedResult<CenterDto>> Get(GetCenterQuery request, CancellationToken cancellationToken);

        Task<CenterDto> GetById(GetCenterByIdQuery request, CancellationToken cancellationToken);

    }
}
