using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Domain;
using MediatR;

namespace AdaTranslation.Application.Demands.Queries.GetDemands
{
    public class GetDemandsQuery : IRequest<PagedResult<DemandSummaryDto>>
    {
        public required Page Page { get; set; }
    }
}
