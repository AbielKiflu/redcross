using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUserByEmail
{
    public record UserGetByEmailQuery(string email) :IRequest<UserDto>;
}
