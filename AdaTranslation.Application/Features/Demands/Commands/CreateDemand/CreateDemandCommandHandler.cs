using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Enums;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, int>
    {
        private readonly IDemandRepository _demandRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateDemandCommandHandler(IDemandRepository demandRepository, ICurrentUserService currentUser)
        {
            _demandRepository = demandRepository;
            _currentUser = currentUser;
        }

        public async Task<int> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.UserId == null || _currentUser.CenterId == null)
                throw new UnauthorizedAccessException("User identification or assigned Center ID is missing from the session.");

            switch (_currentUser.Role)
            {
                case UserRole.Client:
                    request.Demand.Status = DemandStatus.Draft;
                    break;
                default:
                    throw new UnauthorizedAccessException($"The role '{_currentUser.Role}' is not authorized to create demands.");
            }

            var newDemand = new Demand(
                request.Demand.Subject,
                request.Demand.Description,
                _currentUser.CenterId.Value,
                _currentUser.UserId.Value,
                request.Demand.DemandType,
                request.Demand.Priority
            );

            try
            {
                return await _demandRepository.CreateAsync(newDemand, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(
                    "Failed to save the demand. Verify that your User ID and Center ID exist in the system database.", ex);
            }


        }
    }
}
