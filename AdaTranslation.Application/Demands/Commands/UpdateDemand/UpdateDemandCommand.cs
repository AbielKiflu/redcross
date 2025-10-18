using AdaTranslation.Application.Demands.Dtos;
using MediatR;

namespace AdaTranslation.Application.Demands.Commands.UpdateDemand
{
    public record UpdateDemandCommand(DemandUpdate Demand) : IRequest<int>;
}
