using AdaTranslation.Application.Demands.Dtos;
using MediatR;

namespace AdaTranslation.Application.Demands.Queries.GetDemandById
{
    public class GetDemandByIdQuery : IRequest<DemandSummaryDto>
    {
        public long Id { get; set; }
    }
}
