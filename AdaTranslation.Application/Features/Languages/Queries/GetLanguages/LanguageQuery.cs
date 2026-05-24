using AdaTranslation.Application.Features.Languages.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Languages.Queries.GetLanguages
{
    public record LanguageQuery() : IRequest<IEnumerable<LanguageDto>>;
}
