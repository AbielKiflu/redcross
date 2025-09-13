using AdaTranslation.Application.DTOs;

using MediatR;

namespace AdaTranslation.Application.Queries.User
{
    public record UserLoginRequest(string Email) : IRequest<UserDto>;
}
