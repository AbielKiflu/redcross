using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.DTOs.Mappers
{
    public static class ServiceMapper
    {
        public static Service ToService(this ServiceDto serviceDto)
        {
            return new Service { Id = serviceDto.Id, Description = serviceDto.Description };
        }

        public static ServiceDto ToServiceDto(this Service service) 
        {
            return new ServiceDto(Id: service.Id, Description: service.Description);
        } 
    }
}
