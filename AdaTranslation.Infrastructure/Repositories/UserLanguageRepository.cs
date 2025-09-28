using AdaTranslation.Application.Interfaces;
using AdaTranslation.Application.Queries.UserLanguage;

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
