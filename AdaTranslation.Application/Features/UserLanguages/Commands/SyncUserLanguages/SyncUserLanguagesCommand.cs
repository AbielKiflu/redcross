using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.SyncUserLanguages

{
    public class SyncUserLanguagesCommand : IRequest<Unit>
    {
        public long UserId { get; set; }
        public List<int> LanguageIds { get; set; } = [];

        public SyncUserLanguagesCommand(long userId, List<int> languageIds)
        {
            UserId = userId;
            LanguageIds = languageIds;
        }
    }
}
