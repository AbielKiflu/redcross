using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByCenterId
{
    public record UserGetByCenterIdQuery(int centerId) :IRequest<IEnumerable<UserDto>>;
}
