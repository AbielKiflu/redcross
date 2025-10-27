using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.SyncUserLanguages
{
    public class SyncUserLanguagesCommandHandler: IRequestHandler<SyncUserLanguagesCommand,Unit>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public SyncUserLanguagesCommandHandler(IUserLanguageRepository userLanguageRepository)
        {
            _userLanguageRepository = userLanguageRepository;
        }

        public async Task<Unit> Handle(SyncUserLanguagesCommand request, CancellationToken cancellationToken)
        {
            await _userLanguageRepository.SyncUserLanguagesAsync(
                request.UserId,
                request.LanguageIds,
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
