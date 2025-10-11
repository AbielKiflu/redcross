using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage
{
    public class CreateUserLanguageCommandHandler : IRequestHandler<CreateUserLanguageCommand>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public CreateUserLanguageCommandHandler(IUserLanguageRepository userLanguageRepository) => _userLanguageRepository = userLanguageRepository;

        public async Task Handle(CreateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            await _userLanguageRepository.CreateAsync(request.userLanguageCreate, cancellationToken);
        }
    }
}
