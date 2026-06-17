using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Queries.GetDemandsQuery
{
    public class GetDemandsQueryHandler : IRequestHandler<GetDemandsQuery, PagedResult<DemandSummaryDto>>
    {
        private readonly IDemandRepository _demandRepository;
        private readonly ICurrentUserService _currentUser;

        public GetDemandsQueryHandler(ICurrentUserService currentUser, IDemandRepository demandRepository)
        {
            _currentUser = currentUser;
            _demandRepository = demandRepository;
        }
        public async Task<PagedResult<DemandSummaryDto>> Handle(GetDemandsQuery request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                throw new UnauthorizedAccessException("User is unauthenticated.");

            return await _demandRepository.Get(request.Page, cancellationToken);
        }
    }
}
