using AdaTranslation.Application.Features.Services.Dtos;
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Common.Mappers
{
    public static class ServiceMapper
    {
        public static Service ToService(this ServiceDto serviceDto)
        {
            return new Service(serviceDto.Id, serviceDto.Description);
        }

        public static ServiceDto ToServiceDto(this Service service)
        {
            return new ServiceDto(Id: service.Id, Description: service.Description);
        }
    }
}
