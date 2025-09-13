using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, IEnumerable<ServiceDto>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceQueryHandler(IServiceRepository serviceRepository) =>
            _serviceRepository = serviceRepository;

        public async Task<IEnumerable<ServiceDto>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAsync(cancellationToken);

            return services.Select(s => new ServiceDto(s.Id, s.Description));
        }
    }

}
