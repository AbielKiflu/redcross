using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.DTOs.Mappers
{
    public static class LanguageMapper
    {
        public static LanguageDto ToLanguageDto(this Language language) 
        {
            return new LanguageDto(Id: language.Id, Description: language.Description);
        } 
    }
}
