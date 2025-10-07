using MediatR;

namespace AdaTranslation.Application.Services.Commands.UpdateService
{
    public record UpdateServiceCommand(int Id,string Description) : IRequest;
}
