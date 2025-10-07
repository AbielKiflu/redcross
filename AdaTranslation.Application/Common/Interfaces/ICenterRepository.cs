using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Domain;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// This interface is temp. for the moment centers are going to be created by the database admin
    /// </summary>
    public interface ICenterRepository
    {
        Task<PagedResult<CenterDto>> Get(Page page, CancellationToken cancellationToken);

        Task<CenterDto> GetById(int id, CancellationToken cancellationToken);

    }
}
