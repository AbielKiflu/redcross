using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage
{
    public record CreateUserLanguageCommand(int languageId,long userId) : IRequest;
}
