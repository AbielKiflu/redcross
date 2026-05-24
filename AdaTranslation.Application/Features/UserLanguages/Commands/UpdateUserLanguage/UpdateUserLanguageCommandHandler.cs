using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.UpdateUserLanguage
{
    public class UpdateUserLanguageCommandHandler : IRequestHandler<UpdateUserLanguageCommand>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public UpdateUserLanguageCommandHandler(IUserLanguageRepository userLanguageRepository) => _userLanguageRepository=userLanguageRepository;

        public async Task Handle(UpdateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            await _userLanguageRepository.UpdateAsync(request.userLanguageUpdate, cancellationToken);
        }
    }
}
