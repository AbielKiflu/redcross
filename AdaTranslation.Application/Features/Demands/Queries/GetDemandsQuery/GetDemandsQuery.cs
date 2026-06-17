using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemandsQuery
{
    public class GetDemandsQuery : IRequest<PagedResult<DemandSummaryDto>>
    {
        public required Page Page { get; set; }
    }
}
