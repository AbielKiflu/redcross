using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Get language data
    /// </summary>
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAsync(CancellationToken cancellationToken = default);
        Task<Language> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
