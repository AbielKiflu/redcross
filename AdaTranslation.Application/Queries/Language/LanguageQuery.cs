using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.Language
{
    public record LanguageQuery() : IRequest<IEnumerable<LanguageDto>>;
}
