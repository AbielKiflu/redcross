using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Commands.UpdateDemand
{
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, int>
    {
        private readonly IDemandRepository _demandRepository;

        public UpdateDemandCommandHandler(IDemandRepository demandRepository) =>  _demandRepository= demandRepository;

        public async Task<int> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            return await _demandRepository.UpdateAsync(request.Demand, cancellationToken);
        }
    }
}
