using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Domain.Enums;

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
                    throw new KeyNotFoundException($"Demand with ID {request.Id} was not found or you do not have permission to view it.");
            }

            var result = await _demandRepository.GetByIdAsync(
                request.Id,
                _currentUser.Role.Value,
                filterUserId,
                filterCenterId,
                fetchAllData,
                cancellationToken);

            if (result == null)
                throw new KeyNotFoundException($"Demand with ID {request.Id} was not found or you do not have permission to view it.");

            return result;
        }
    }
}
