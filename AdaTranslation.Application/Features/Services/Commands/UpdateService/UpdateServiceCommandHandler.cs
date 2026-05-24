using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Services.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new ServiceDto(Id:request.Id , Description:request.Description);

            await _serviceRepository.UpdateAsync(service, cancellationToken);
        }
    }
}
