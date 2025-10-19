using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUsers
{
    public record UserGetAllQuery() :IRequest<IEnumerable<UserDto>>;
}
