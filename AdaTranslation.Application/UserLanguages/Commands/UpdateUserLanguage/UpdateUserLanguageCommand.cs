using AdaTranslation.Application.UserLanguages.Dtos;
using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.UpdateUserLanguage
{
    public record UpdateUserLanguageCommand(UserLanguageUpdateDto userLanguageUpdate) : IRequest;
}
