using AdaTranslation.Application.Features.Centers.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Centers.Queries.GetCenterById
{
    public class GetCenterByIdQuery : IRequest<CenterDto>
    {
        public int Id { get; set; }
    }
}
