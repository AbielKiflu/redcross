using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record  GetServiceQuery(): IRequest<IEnumerable<ServiceDto>>;
}
