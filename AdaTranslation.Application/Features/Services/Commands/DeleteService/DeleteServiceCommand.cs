using MediatR;

namespace AdaTranslation.Application.Features.Services.Commands.DeleteService
{
    public record DeleteServiceCommand(int Id) : IRequest;
}
