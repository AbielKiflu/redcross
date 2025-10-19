using AdaTranslation.Application.UserLanguages.Dtos;
using MediatR;

namespace AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage
{
    public record CreateUserLanguageCommand(UserLanguageCreateDto userLanguageCreate) : IRequest;
}
