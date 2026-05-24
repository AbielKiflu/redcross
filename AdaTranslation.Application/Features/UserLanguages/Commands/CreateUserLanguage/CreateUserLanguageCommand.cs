using AdaTranslation.Application.Features.UserLanguages.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.UserLanguages.Commands.CreateUserLanguage
{
    public record CreateUserLanguageCommand(UserLanguageCreateDto userLanguageCreate) : IRequest;
}
