using AdaTranslation.Application.Demands.Dtos;
using MediatR;

namespace AdaTranslation.Application.Demands.Commands.UpdateDemandAdmin
{
    public record UpdateDemandAdminCommand(DemandUpdateAdmin Demand) : IRequest<int>;
}
