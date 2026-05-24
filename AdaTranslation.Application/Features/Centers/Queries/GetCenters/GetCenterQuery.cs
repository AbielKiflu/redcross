using AdaTranslation.Application.Features.Centers.Dtos;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Features.Centers.Queries.GetCenters
{
    public record GetCenterQuery(Page page): IRequest<PagedResult<CenterDto>>;
}
