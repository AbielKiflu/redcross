using AdaTranslation.Application.Languages.Dtos;
using MediatR;

namespace AdaTranslation.Application.Languages.Queries.GetLanguages
{
    public record LanguageQuery() : IRequest<IEnumerable<LanguageDto>>;
}
