using AdaTranslation.Application.Centers.Dtos;
using MediatR;

namespace AdaTranslation.Application.Centers.Queries.GetCenterById
{
    public class GetCenterByIdQuery : IRequest<CenterDto>
    {
        public int Id { get; set; }
    }
}
