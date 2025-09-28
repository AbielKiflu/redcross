using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record  GetServiceByIdQuery(int Id): IRequest<ServiceDto>;
}
