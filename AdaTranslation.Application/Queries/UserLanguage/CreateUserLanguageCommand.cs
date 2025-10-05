using MediatR;

namespace AdaTranslation.Application.Queries.UserLanguage
{
    public record CreateUserLanguageCommand(int languageId,long userId) : IRequest;
}
