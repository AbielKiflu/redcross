using AdaTranslation.Application.Users.Dtos;

namespace AdaTranslation.Application.Centers.Dtos
{
    public record CenterDto(
     long Id,
     string Description,
     string Address,
     string Contact,
     List<UserDto> Users
 );
}


