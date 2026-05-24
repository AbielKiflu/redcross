using AdaTranslation.Application.Features.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Services.Queries.GetServiceById
{
    public record  GetServiceByIdQuery(int Id): IRequest<ServiceDto>;
}
