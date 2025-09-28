using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.UserLanguage
{
    public class UpdateUserLanguageCommandHandler : IRequestHandler<UpdateUserLanguageCommand>
    {
        private readonly IUserLanguageRepository _userLanguageRepository;

        public UpdateUserLanguageCommandHandler(IUserLanguageRepository userLanguageRepository) => _userLanguageRepository=userLanguageRepository;

        public async Task Handle(UpdateUserLanguageCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
