using AdaTranslation.Application.Features.UserLanguages.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.UpdateUserLanguage
{
    public record UpdateUserLanguageCommand(UserLanguageUpdateDto userLanguageUpdate) : IRequest;
}
