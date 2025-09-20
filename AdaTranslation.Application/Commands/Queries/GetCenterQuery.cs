using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Commands.Queries
{
    public class GetCenterQuery : IRequest<IEnumerable<CenterDto>>
    {
        public GetCenterQuery()
        {
            
        }

    }
}
