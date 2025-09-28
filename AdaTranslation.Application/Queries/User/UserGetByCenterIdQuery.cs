using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserGetByCenterIdQuery(int centerId) :IRequest<IEnumerable<UserDto>>;
}
