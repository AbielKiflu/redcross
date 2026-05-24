using AdaTranslation.Application.Features.Demands.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemandById
{
    public class GetDemandByIdQuery : IRequest<DemandSummaryDto>
    {
        public long Id { get; set; }
    }
}
