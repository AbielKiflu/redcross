using AdaTranslation.Application.Features.Centers.Dtos;
using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Application.Features.Languages.Dtos;
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Common.Mappers
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
                Center: new CenterBaseDto(
                    Id: user.Center.Id,
                    Description: user.Center.Description,
                    Address: user.Center.Address,
                    Contact: user.Center.Contact
                ),
                UserRole: user.UserRole.ToString(),
                Languages: [.. user.UserLanguages
                    .Select(ul => new LanguageDto(
                        Id: ul.Language.Id,
                        Description: ul.Language.Description
                    ))]
            );
        }
    }


}
