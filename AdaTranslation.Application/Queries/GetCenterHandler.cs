using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries
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
            return await _centerRepository.Get(request, cancellationToken);
        }
    }
}
