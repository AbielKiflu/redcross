using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Task<IEnumerable<CenterDto>> GetAll();
    }
}
