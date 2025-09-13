using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Mappers;
using AdaTranslation.Application.Interfaces;
using MediatR;

namespace AdaTranslation.Application.Queries.Language
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
