using AdaTranslation.Application.Common.Interfaces;

using MediatR;

namespace AdaTranslation.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceRepository.CreateAsync(request.Description, cancellationToken);
        }
    }
}
