using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.DeleteUserLanguage
{
    public class DeleteUserLanguageHandler : IRequestHandler<DeleteUserLanguageCommand>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public DeleteUserLanguageHandler(IUserLanguageRepository userLanguageRepository)
        {
            _userLanguageRepository = userLanguageRepository;
        }
        public async Task Handle(DeleteUserLanguageCommand request, CancellationToken cancellationToken)
        {
            await _userLanguageRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
