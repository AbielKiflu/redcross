using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Enums;

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

            long? filterUserId = null;
            long? filterCenterId = null;
            bool fetchAllData = false;

            switch (_currentUser.Role)
            {
                case UserRole.Admin:
                case UserRole.Coordinator:
                    fetchAllData = true;
                    break;

                case UserRole.Client:
                    filterUserId = _currentUser.UserId;
                    filterCenterId = _currentUser.CenterId;
                    break;

                case UserRole.Mediator:
                    filterUserId = _currentUser.UserId;
                    break;

                default:
                    return new PagedResult<DemandSummaryDto> { PageNumber = request.Page.PageNumber, PageSize = request.Page.PageSize };
            }

            return await _demandRepository.GetAsync(
                request.Page,
                _currentUser.Role.Value,
                filterUserId,
                filterCenterId,
                fetchAllData,
                cancellationToken);
        }
    }
}
