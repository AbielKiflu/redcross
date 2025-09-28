using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
         
        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id,cancellationToken);

            return new ServiceDto(service.Id, service.Description);
        }
    }
}
