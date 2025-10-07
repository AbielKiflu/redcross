using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage;
using AdaTranslation.Application.UserLanguages.Commands.UpdateUserLanguage;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class UserLanguageRepository : IUserLanguageRepository
    {
        public Task CreateAsync(CreateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
