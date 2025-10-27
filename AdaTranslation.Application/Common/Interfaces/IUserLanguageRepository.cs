using AdaTranslation.Application.UserLanguages.Dtos;

namespace AdaTranslation.Application.Common.Interfaces
{
    public interface IUserLanguageRepository
    {
        /// <summary>
        /// Creates a single UserLanguage link (skips if it already exists).
        /// </summary>
        Task CreateAsync(UserLanguageCreateDto createUserLanguage, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing UserLanguage record.
        /// </summary>
        Task UpdateAsync(UserLanguageUpdateDto updateUserLanguage, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a UserLanguage record by Id.
        /// </summary>
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Synchronizes a user's languages:
        /// - Adds new languages not currently linked.
        /// - Removes deselected languages.
        /// - Keeps existing ones unchanged.
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="newLanguageIds">List of language Ids currently selected</param>
        /// <param name="cancellationToken"></param>
        Task SyncUserLanguagesAsync(long userId, List<int> newLanguageIds, CancellationToken cancellationToken);
    }
}
