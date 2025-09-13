using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Enums;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserGetByUserRoleQuery(UserRole role) :IRequest<IEnumerable<UserDto>>;
}
