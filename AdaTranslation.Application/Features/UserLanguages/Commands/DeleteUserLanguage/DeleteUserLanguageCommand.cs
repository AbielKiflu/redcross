using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.DeleteUserLanguage
{
    public record DeleteUserLanguageCommand(int Id) : IRequest;
}
