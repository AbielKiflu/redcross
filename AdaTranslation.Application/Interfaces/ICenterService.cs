using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Application.Interfaces
{
    public interface ICenterService
    {
        Task<IEnumerable<CenterDto>> GetAllCentersAsync();
    }
}
