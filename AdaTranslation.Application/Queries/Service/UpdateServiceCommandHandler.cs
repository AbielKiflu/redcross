using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service
            {
                Id = request.Id,
                Description = request.Description
            };

            await _serviceRepository.UpdateAsync(service, cancellationToken);
        }
    }
}
