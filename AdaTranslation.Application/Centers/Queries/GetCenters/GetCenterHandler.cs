using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Domain;
using MediatR;

namespace AdaTranslation.Application.Centers.Queries.GetCenters
{
    public class GetCenterHandler : IRequestHandler<GetCenterQuery, PagedResult<CenterDto>>
    {
        private readonly ICenterRepository _centerRepository;

        public GetCenterHandler(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<PagedResult<CenterDto>> Handle(GetCenterQuery request, CancellationToken cancellationToken)
        {
            return await _centerRepository.Get(request.page, cancellationToken);
        }
    }
}
