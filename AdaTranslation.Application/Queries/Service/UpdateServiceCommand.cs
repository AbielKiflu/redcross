using MediatR;

namespace AdaTranslation.Application.Queries.Service
{
    public record UpdateServiceCommand(int Id,string Description) : IRequest;
}
