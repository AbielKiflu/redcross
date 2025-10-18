using AdaTranslation.Application.Demands.Dtos;
using MediatR;

namespace AdaTranslation.Application.Demands.Commands.CreateDemand
{
    public record CreateDemandCommand(DemandCreateDto Demand) : IRequest<int>;
}
