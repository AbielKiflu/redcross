using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Domain.Enums;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByRoleAndCenterId
{
    public record UserGetByCenterIdAndUserRoleQuery(int centerId,UserRole role) :IRequest<IEnumerable<UserDto>>;
}
