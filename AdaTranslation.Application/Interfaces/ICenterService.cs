using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Interfaces
{
    public interface ICenterService
    {
        Task<IEnumerable<Center>> GetAllCentersAsync();
    }
}
