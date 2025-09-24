using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries
{
    public class GetCenterByIdQuery : IRequest<CenterDto>
    {
        public int Id { get; set; }
    }
}
