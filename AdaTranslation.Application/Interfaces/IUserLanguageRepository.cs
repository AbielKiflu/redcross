using AdaTranslation.Application.Queries.UserLanguage;

namespace AdaTranslation.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserLanguageRepository
    {
        Task CreateAsync(CreateUserLanguageCommand request, CancellationToken cancellationToken);
        Task UpdateAsync(UpdateUserLanguageCommand request, CancellationToken cancellationToken);

    }
}
