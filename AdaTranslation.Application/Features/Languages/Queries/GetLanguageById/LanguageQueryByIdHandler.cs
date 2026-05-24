using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Mappers;
using AdaTranslation.Application.Features.Languages.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Languages.Queries.GetLanguageById
{
    public class LanguageQueryByIdHandler : IRequestHandler<LanguageByIdQuery, LanguageDto>
    {
        ILanguageRepository _languageRepository;
        public LanguageQueryByIdHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public async Task<LanguageDto> Handle(LanguageByIdQuery request, CancellationToken cancellationToken)
        {
            var language = await _languageRepository.GetByIdAsync(request.Id, cancellationToken);
            return language.ToLanguageDto();
        }
    }
}
