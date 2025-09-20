using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries
{
    public class GetCenterQuery : IRequest<IEnumerable<CenterDto>>
    {
        public GetCenterQuery()
        {
            
        }

    }
}
