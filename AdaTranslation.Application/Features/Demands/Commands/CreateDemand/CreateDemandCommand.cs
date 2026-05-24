using AdaTranslation.Application.Features.Demands.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Commands.CreateDemand
{
    public record CreateDemandCommand(DemandCreateDto Demand) : IRequest<int>;
}
