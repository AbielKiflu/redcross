using MediatR;

namespace AdaTranslation.Application.Features.Services.Commands.UpdateService
{
    public record UpdateServiceCommand(int Id,string Description) : IRequest;
}
