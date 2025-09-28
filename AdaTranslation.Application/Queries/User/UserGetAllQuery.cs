using AdaTranslation.Application.DTOs;
using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserGetAllQuery() :IRequest<IEnumerable<UserDto>>;
}
