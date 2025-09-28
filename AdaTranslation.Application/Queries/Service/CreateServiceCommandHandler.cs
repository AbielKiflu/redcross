using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service
            {
                Description = request.Description
            };

            await _serviceRepository.CreateAsync(service, cancellationToken);
        }
    }
}
