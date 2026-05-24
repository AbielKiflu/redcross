using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemandById
{
    public class GetDemandByIdHandler : IRequestHandler <GetDemandByIdQuery, DemandSummaryDto>
    {
        private readonly IDemandRepository _demandRepository;

        public GetDemandByIdHandler(IDemandRepository demandRepository)
        {
            _demandRepository = demandRepository;
        }

        public async Task<DemandSummaryDto> Handle(GetDemandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _demandRepository.GetById(request.Id, cancellationToken);
        }
    }
}
