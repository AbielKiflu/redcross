using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Center
{
    public class GetCenterByIdHandler : IRequestHandler <GetCenterByIdQuery, CenterDto>
    {
        private readonly ICenterRepository _centerRepository;

        public GetCenterByIdHandler(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<CenterDto> Handle(GetCenterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _centerRepository.GetById(request, cancellationToken);
        }
    }
}
