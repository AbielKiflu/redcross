using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.UserLanguage
{
    public class CreateUserLanguageCommandHandler : IRequestHandler<CreateUserLanguageCommand>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public CreateUserLanguageCommandHandler(IUserLanguageRepository userLanguageRepository) => _userLanguageRepository = userLanguageRepository;

        public async Task Handle(CreateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
