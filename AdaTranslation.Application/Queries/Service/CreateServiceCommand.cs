using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record CreateServiceCommand(string Description) : IRequest;
}
