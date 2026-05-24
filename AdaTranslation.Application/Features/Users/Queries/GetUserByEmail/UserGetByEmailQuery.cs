using AdaTranslation.Application.Features.Users.Dtos;

using MediatR;

namespace AdaTranslation.Application.Features.Users.Queries.GetUserByEmail
{
    public record UserGetByEmailQuery(string email) :IRequest<UserDto>;
}
