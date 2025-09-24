using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain;
using MediatR;

namespace AdaTranslation.Application.Queries
{
    public class GetCenterByIdQuery : IRequest<CenterDto>
    {
        public int Id { get; set; }
    }
}
