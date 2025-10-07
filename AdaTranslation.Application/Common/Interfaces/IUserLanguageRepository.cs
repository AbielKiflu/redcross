using AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage;
using AdaTranslation.Application.UserLanguages.Commands.UpdateUserLanguage;

namespace AdaTranslation.Application.Common.Interfaces
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
