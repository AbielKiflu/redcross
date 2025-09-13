
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Task<IEnumerable<Center>> GetAll();
    }
}
