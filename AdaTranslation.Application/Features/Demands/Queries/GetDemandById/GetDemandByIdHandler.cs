using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemandById
{
    public class GetDemandByIdHandler : IRequestHandler<GetDemandByIdQuery, DemandSummaryDto>
    {
        private readonly IDemandRepository _demandRepository;
        private readonly ICurrentUserService _currentUser;

        public GetDemandByIdHandler(IDemandRepository demandRepository, ICurrentUserService currentUser)
        {
            _demandRepository = demandRepository;
            _currentUser = currentUser;
        }

        public async Task<DemandSummaryDto> Handle(GetDemandByIdQuery request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                throw new UnauthorizedAccessException("User is unauthenticated.");

            return await _demandRepository.GetById(request.Id, cancellationToken);
        }
    }
}
