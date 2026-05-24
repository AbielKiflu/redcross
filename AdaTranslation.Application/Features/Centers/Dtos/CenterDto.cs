using AdaTranslation.Application.Features.Users.Dtos;

namespace AdaTranslation.Application.Features.Centers.Dtos
{
    public record CenterDto(
     long Id,
     string Description,
     string Address,
     string Contact,
     List<UserDto> Users
 );
}


