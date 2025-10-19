using AdaTranslation.Application.UserLanguages.Dtos;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Create and update user language
    /// </summary>
    public interface IUserLanguageRepository
    {
        Task CreateAsync(UserLanguageCreateDto createUserLanguage,CancellationToken cancellationToken);
        Task UpdateAsync(UserLanguageUpdateDto updateUserLanguage,CancellationToken cancellationToken);
        Task DeleteAsync(int Id, CancellationToken cancellationToken);
    }
}
