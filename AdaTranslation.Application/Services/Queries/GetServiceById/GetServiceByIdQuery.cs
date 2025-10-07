using AdaTranslation.Application.Services.Dtos;

using MediatR;

namespace AdaTranslation.Application.Services.Queries.GetServiceById
{
    public record  GetServiceByIdQuery(int Id): IRequest<ServiceDto>;
}
