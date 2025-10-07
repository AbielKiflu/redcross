using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Services.Queries.GetServiceById
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
