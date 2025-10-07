using MediatR;

namespace AdaTranslation.Application.Services.Commands.DeleteService
{
    public record DeleteServiceCommand(int Id) : IRequest;
}
