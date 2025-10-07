using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Services.Queries.GetServices
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
