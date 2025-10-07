using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Application.Common.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Centers.Queries.GetCenterById
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
            return await _centerRepository.GetById(request.Id, cancellationToken);
        }
    }
}
