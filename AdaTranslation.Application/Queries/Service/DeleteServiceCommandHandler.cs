using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

        public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
