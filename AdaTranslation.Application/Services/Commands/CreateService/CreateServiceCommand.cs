using MediatR;

namespace AdaTranslation.Application.Services.Commands.CreateService
{
    public record CreateServiceCommand(string Description) : IRequest;
}
