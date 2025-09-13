using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.Language
{
    public record LanguageByIdQuery(int Id) : IRequest<LanguageDto>;
}
