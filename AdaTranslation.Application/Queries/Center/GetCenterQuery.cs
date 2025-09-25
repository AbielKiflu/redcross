using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain;

using MediatR;

namespace AdaTranslation.Application.Queries.Center
{
    public class GetCenterQuery : IRequest<PagedResult<CenterDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; 
    }
}
