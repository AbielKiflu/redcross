using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Interfaces
{
    public interface ICenterRepository
    {
        Task<IEnumerable<Center>> GetAll();
    }
}
