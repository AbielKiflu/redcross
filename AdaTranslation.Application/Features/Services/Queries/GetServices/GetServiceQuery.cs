using AdaTranslation.Application.Features.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Services.Queries.GetServices
{
    public record GetServiceQuery() : IRequest<IEnumerable<ServiceDto>>;
}
