using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Domain.Enums;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsersByRole
{
    public record UserGetByUserRoleQuery(UserRole role) :IRequest<IEnumerable<UserDto>>;
}
