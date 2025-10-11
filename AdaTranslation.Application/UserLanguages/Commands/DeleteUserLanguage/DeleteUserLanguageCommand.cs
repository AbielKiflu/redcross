using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.DeleteUserLanguage
{
    public record DeleteUserLanguageCommand(int Id):IRequest;
}
