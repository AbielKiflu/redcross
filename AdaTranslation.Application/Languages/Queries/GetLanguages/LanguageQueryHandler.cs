using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Languages.Dtos;
using MediatR;

namespace AdaTranslation.Application.Languages.Queries.GetLanguages
{
    public class LanguageQueryHandler : IRequestHandler<LanguageQuery, IEnumerable<LanguageDto>>
    {
        ILanguageRepository _languageRepository;
        public LanguageQueryHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public async Task<IEnumerable<LanguageDto>> Handle(LanguageQuery request, CancellationToken cancellationToken)
        {
            var languages = await _languageRepository.GetAsync(cancellationToken);
            return languages.Select(l => new LanguageDto(Id: l.Id,Description:l.Description));
        }
    }
}
