using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record DeleteServiceCommand(int Id) : IRequest;
}
