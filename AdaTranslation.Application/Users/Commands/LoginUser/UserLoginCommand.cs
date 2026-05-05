using AdaTranslation.Application.Common;
using MediatR;

namespace AdaTranslation.Application.Users.Commands.LoginUser
{
    public record UserLoginCommand
    (
    string Email,
    string Password
    ) : IRequest<AuthResponse>;
}
