using MediatR;

namespace AdaTranslation.Application.Features.Services.Commands.CreateService
{
    public record CreateServiceCommand(string Description) : IRequest;
}
