using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.Centers.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Centers.Queries.GetCenterById
{
    public class GetCenterByIdHandler : IRequestHandler<GetCenterByIdQuery, CenterDto>
    {
        private readonly ICenterRepository _centerRepository;

        public GetCenterByIdHandler(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<CenterDto> Handle(GetCenterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _centerRepository.GetById(request.Id, cancellationToken);
        }
    }
}
