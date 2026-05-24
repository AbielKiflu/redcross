using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemands
{
    public class GetDemandsHandler : IRequestHandler <GetDemandsQuery, PagedResult<DemandSummaryDto>>
    {
        private readonly IDemandRepository _demandRepository;

        public GetDemandsHandler(IDemandRepository demandRepository)
        {
            _demandRepository = demandRepository;
        }

        public async Task<PagedResult<DemandSummaryDto>> Handle(GetDemandsQuery request, CancellationToken cancellationToken)
        {
            return await _demandRepository.Get(request.Page, cancellationToken);
        }
    }
}
