using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Domain;
using MediatR;

namespace AdaTranslation.Application.Centers.Queries.GetCenters
{
    public record GetCenterQuery(Page page): IRequest<PagedResult<CenterDto>>;
}
