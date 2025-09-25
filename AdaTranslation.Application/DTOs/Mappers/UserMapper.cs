using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.DTOs.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(User user)
        {
            return new UserDto(
                Id: user.Id,
                LastName: user.LastName,
                FirstName: user.FirstName,
                Telephone: user.Telephone,
                Email: user.Email,
                PauseStartDate: user.PauseStartDate,
                PauseEndDate: user.PauseEndDate,
                GoogleId: user.GoogleId,
                Center: new UserCenterDto(
                    Id: user.Center.Id,
                    Description: user.Center.Description,
                    Address: user.Center.Address,
                    Contact: user.Center.Contact
                ),
                UserRole: user.UserRole.ToString(),
                Languages: user.UserLanguages
                    .Select(ul => new UserLanguageDto(
                        LanguageId: ul.Language.Id,
                        LanguageName: ul.Language.Description
                    ))
                    .ToList()
            );
        }
    }


}
