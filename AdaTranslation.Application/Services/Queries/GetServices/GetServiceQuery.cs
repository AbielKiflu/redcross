using AdaTranslation.Application.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Services.Queries.GetServices
{
    public record  GetServiceQuery(): IRequest<IEnumerable<ServiceDto>>;
}
