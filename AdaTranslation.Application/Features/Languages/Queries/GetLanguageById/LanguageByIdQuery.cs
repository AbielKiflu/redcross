using AdaTranslation.Application.Features.Languages.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Languages.Queries.GetLanguageById
{
    public record LanguageByIdQuery(int Id) : IRequest<LanguageDto>;
}
