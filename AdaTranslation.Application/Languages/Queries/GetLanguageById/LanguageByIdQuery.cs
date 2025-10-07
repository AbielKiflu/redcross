using AdaTranslation.Application.Languages.Dtos;
using MediatR;

namespace AdaTranslation.Application.Languages.Queries.GetLanguageById
{
    public record LanguageByIdQuery(int Id) : IRequest<LanguageDto>;
}
