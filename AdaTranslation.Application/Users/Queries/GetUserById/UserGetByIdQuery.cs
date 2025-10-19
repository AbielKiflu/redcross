using AdaTranslation.Application.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Users.Queries.GetUserById
{
    public record UserGetByIdQuery(int id) :IRequest<UserDto>;
}
