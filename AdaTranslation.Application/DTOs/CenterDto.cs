namespace AdaTranslation.Application.DTOs
{
    public record CenterDto(
     long Id,
     string Description,
     string Address,
     string Contact,
     List<UserDto> Users
 );

}


