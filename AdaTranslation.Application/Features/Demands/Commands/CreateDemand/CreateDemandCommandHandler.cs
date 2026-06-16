using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, int>
    {
        private readonly IDemandRepository _demandRepository;

        public CreateDemandCommandHandler(IDemandRepository demandRepository) => _demandRepository = demandRepository;

        public async Task<int> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            return await _demandRepository.CreateAsync(request.Demand, cancellationToken);
        }
    }
}
