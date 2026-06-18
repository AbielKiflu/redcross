using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Domain.Enums;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Commands.UpdateDemand
{
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, int>
    {
        private readonly IDemandRepository _demandRepository;
        private readonly ICurrentUserService _currentUser;

        public UpdateDemandCommandHandler(IDemandRepository demandRepository, ICurrentUserService currentUser)
        {
            _demandRepository = demandRepository;
            _currentUser = currentUser;
        }

        public async Task<int> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.UserId == null || _currentUser.CenterId == null)
                throw new UnauthorizedAccessException("User identification or assigned Center ID is missing from the session.");

            var existingDemand = await _demandRepository.GetByIdAsync(request.Demand.Id, cancellationToken);

            if (existingDemand == null)
                throw new KeyNotFoundException($"Demand with ID {request.Demand.Id} was not found or you do not have permission to modify it.");

            var updatedDemand = existingDemand.Update(request.Demand.Subject, request.Demand.Description, request.Demand.DemandType)
                .ChangePriority(request.Demand.Priority);

            switch (_currentUser.Role)
            {
                case UserRole.Client:
                    if (existingDemand.CenterId != _currentUser.CenterId && existingDemand.CreatedById != _currentUser.UserId)
                        throw new UnauthorizedAccessException("You do not have permission to modify this demand.");

                    if (existingDemand.Status != DemandStatus.Draft)
                        throw new InvalidOperationException("Clients cannot modify if a demand is not a draft");
                    break;

                case UserRole.Admin:
                case UserRole.Coordinator:
                    break;

                default:
                    throw new UnauthorizedAccessException($"The role '{_currentUser.Role}' is not authorized to update demands.");
            }

            return await _demandRepository.UpdateAsync(updatedDemand, cancellationToken);

        }
    }
}
