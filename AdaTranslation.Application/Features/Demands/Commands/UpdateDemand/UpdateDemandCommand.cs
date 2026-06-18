using AdaTranslation.Application.Features.Demands.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Demands.Commands.UpdateDemand
{
    public record UpdateDemandCommand(DemandUpdateDto Demand) : IRequest<int>;
}
