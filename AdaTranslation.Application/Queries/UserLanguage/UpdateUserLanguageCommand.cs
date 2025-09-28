using MediatR;

namespace AdaTranslation.Application.Queries.UserLanguage
{
    public record UpdateUserLanguageCommand(long id,int languageId,long userId) : IRequest;
}
