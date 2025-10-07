using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.UpdateUserLanguage
{
    public record UpdateUserLanguageCommand(long id,int languageId,long userId) : IRequest;
}
