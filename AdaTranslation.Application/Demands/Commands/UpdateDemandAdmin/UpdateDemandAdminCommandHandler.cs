using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Demands.Commands.UpdateDemandAdmin
{
    public class UpdateDemandAdminCommandHandler : IRequestHandler<UpdateDemandAdminCommand, int>
    {
        private readonly IDemandRepository _demandRepository;

        public UpdateDemandAdminCommandHandler(IDemandRepository demandRepository) =>  _demandRepository= demandRepository;

        public async Task<int> Handle(UpdateDemandAdminCommand request, CancellationToken cancellationToken)
        {
            return await _demandRepository.UpdateAdminAsync(request.Demand, cancellationToken);
        }
    }
}
