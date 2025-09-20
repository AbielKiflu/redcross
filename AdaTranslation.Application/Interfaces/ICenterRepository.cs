using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Domain.Interfaces
{
    /// <summary>
    ///  A repo to make a crud on the table center
    /// </summary>
    public interface ICenterRepository
    {
        Task<IEnumerable<CenterDto>> Get();
    }
}
